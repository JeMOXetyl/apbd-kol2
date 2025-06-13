using KolE.Data;
using KolE.DTOs;
using KolE.Exceptions;
using KolE.Models;
using Microsoft.EntityFrameworkCore;

namespace KolE.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<NurseryDetailsDto> GetNursery(int nurseryId)
    {
        var nursery = await _context.Nurseries
            .Include(n => n.Batches)
                .ThenInclude(b => b.Species)
            .Include(n => n.Batches)
                .ThenInclude(b => b.Responsibles)
                    .ThenInclude(r => r.Employee)
            .FirstOrDefaultAsync(n => n.NurseryId == nurseryId);

        return new NurseryDetailsDto()
        {
            NurseryId = nursery.NurseryId,
            Name = nursery.Name,
            EstabilishedDate = nursery.EstablilishedDate,
            Batches = nursery.Batches.Select(b => new SeedlingBatchesDetailsDto()
            {
                BatchId = b.BatchId,
                Quantity = b.Quantity,
                SownDate = b.SownDate,
                ReadyDate = b.ReadyDate,
                Species = new SpeciesDetailsDto()
                {
                    LatinName = b.Species.LatinName,
                    GrowthTimeInYears = b.Species.GrowthTimeInYears
                },
                Responsible = b.Responsibles.Select(r => new ResponsibleDetailsDto()
                {
                    FirstName = r.Employee.FirstName,
                    LastName = r.Employee.LastName,
                    Role = r.Role
                }).ToList()
            }).ToList()
        };
    }

    public async Task AddSeedlingBatches(AddSeedlingBatchDto addBatchDto)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            var species = await _context.TreeSpecies
                .FirstOrDefaultAsync(s => s.LatinName == addBatchDto.Species);

            if (species == null)
            {
                throw new NotFoundException("Species not found");
            }

            var nursery = await _context.Nurseries
                .FirstOrDefaultAsync(n => n.Name == addBatchDto.Nursery);

            if (nursery == null)
            {
                throw new NotFoundException("Nursery not found");
            }

            var empIds = addBatchDto.Responsible.Select(r => r.EmployeeId).ToList();

            foreach (var empId in empIds)
            {
                var employee = await _context.Employees
                    .FirstOrDefaultAsync(e => e.EmployeeId == empId);
                if (employee == null)
                {
                    throw new NotFoundException("Employee not found");
                }
            }
            
            var lastId = await _context.Nurseries.Select(n => n.NurseryId).MaxAsync();
            lastId += 1;

            var batch = new SeedlingBatch()
            {
                BatchId = lastId,
                NurseryId = nursery.NurseryId,
                SpeciesId = species.SpeciesId,
                Quantity = addBatchDto.Quantity,
                SownDate = new DateTime(),
                ReadyDate = null,
                Responsibles = addBatchDto.Responsible.Select(r => new Responsible()
                {
                    BatchId = lastId,
                    EmployeeId = r.EmployeeId,
                    Role = r.Role
                }).ToList()
            };

            await _context.SeedlingBatches.AddAsync(batch);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}