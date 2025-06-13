using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolE.Models;

[Table("Tree_Species")]
public class TreeSpecies
{
    [Key]
    public int SpeciesId { get; set; }
    [Required]
    [MaxLength(100)]
    public string LatinName { get; set; }
    [Required]
    public int GrowthTimeInYears { get; set; }
    
    public ICollection<SeedlingBatch>? Batches { get; set; }
}