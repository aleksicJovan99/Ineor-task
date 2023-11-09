using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;
public class Director
{
    [Column("DirectorId")]
    public int Id { get; set; }
    [Required(ErrorMessage = "Director name is required field")]
    public string? Name { get; set; }
    public ICollection<Movie>? Movies { get; set; }
}
