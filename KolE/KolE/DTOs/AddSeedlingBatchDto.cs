namespace KolE.DTOs;

public class AddSeedlingBatchDto
{
    public int Quantity { get; set; }
    public string Species { get; set; }
    public string Nursery { get; set; }
    public List<AddResponsibleDto> Responsible { get; set; }
}

public class AddResponsibleDto
{
    public int EmployeeId { get; set; }
    public string Role { get; set; }
}