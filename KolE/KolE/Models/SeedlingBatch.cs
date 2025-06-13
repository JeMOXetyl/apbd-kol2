using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolE.Models;

[Table("Seedling_Batch")]
public class SeedlingBatch
{
    [Key]
    public int BatchId { get; set; }
    [ForeignKey(nameof(Nursery))]
    public int NurseryId { get; set; }
    [ForeignKey(nameof(Species))]
    public int SpeciesId { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public DateTime SownDate { get; set; }
    public DateTime? ReadyDate { get; set; }
    
    public ICollection<Responsible>? Responsibles { get; set; }
    
    public Nursery Nursery { get; set; }
    public TreeSpecies Species { get; set; }
}