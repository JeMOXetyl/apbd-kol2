using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KolE.Models;

[PrimaryKey(nameof(BatchId), nameof(EmployeeId))]
[Table("Responsible")]
public class Responsible
{
    [ForeignKey(nameof(Batch))]
    public int BatchId { get; set; }
    [ForeignKey(nameof(Employee))]
    public int EmployeeId { get; set; }
    [Required]
    [MaxLength(100)]
    public string Role { get; set; }
    

    public SeedlingBatch Batch { get; set; }
    public Employee Employee { get; set; }
}