using KolE.DTOs;

namespace KolE.Services;

public interface IDbService
{
    public Task<NurseryDetailsDto> GetNursery(int nurseryId);
    public Task AddSeedlingBatches(AddSeedlingBatchDto addBatchDto);
}