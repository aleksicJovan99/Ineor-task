using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities;
public class Movie
{
    [Column("MovieId")]
    public int Id { get; set; }
    [Required(ErrorMessage = "Movie name is required field")]
    public string Name { get; set; }
    [Range(0.1, 10.0, ErrorMessage = "Rating must between 0.0 and 10.0")]
    [Precision(18,2)]
    public decimal Rating { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    [ForeignKey(nameof(Director))]
    public int DirectorId { get; set; }
    public Director Director { get; set; }
}
