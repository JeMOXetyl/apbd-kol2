namespace KolE.DTOs;

public class NurseryDetailsDto
{
    public int NurseryId { get; set; }
    public string Name { get; set; }
    public DateTime EstabilishedDate { get; set; }
    public List<SeedlingBatchesDetailsDto> Batches { get; set; }
}

public class SeedlingBatchesDetailsDto
{
    public int BatchId { get; set; }
    public int Quantity { get; set; }
    public DateTime SownDate { get; set; }
    public DateTime? ReadyDate { get; set; }
    public SpeciesDetailsDto Species { get; set; }
    public List<ResponsibleDetailsDto> Responsible { get; set; }
}

public class SpeciesDetailsDto
{
    public string LatinName { get; set; }
    public int GrowthTimeInYears { get; set; }
}

public class ResponsibleDetailsDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
}

