using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;
public class Movie
{
    [Column("MovieId")]
    public int Id { get; set; }
    [Required(ErrorMessage = "Movie name is required field")]
    public string Name { get; set; }
    [Range(0.0, 10.0, ErrorMessage = "Rating must between 0.0 and 10.0")]
    public decimal Rating { get; set; }
    [DataType(DataType.Date)]
    public DateOnly ReleaseDate { get; set; }
    [ForeignKey(nameof(Director))]
    public int DirectorId { get; set; }
    public Director Director { get; set; }
}
