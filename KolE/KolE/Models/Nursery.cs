using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolE.Models;

[Table("Nursery")]
public class Nursery
{
    [Key]
    public int NurseryId { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    public DateTime EstablilishedDate { get; set; }
    
    public ICollection<SeedlingBatch>? Batches { get; set; } 
}