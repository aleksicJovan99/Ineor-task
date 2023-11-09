using System.ComponentModel.DataAnnotations;

namespace Entities;
public abstract class MovieForManipulationDto
{
    [Required(ErrorMessage = "Movie name is required field")]
    public string? Name { get; set; }
    [Range(typeof(decimal), "0", "10", ErrorMessage = "Rating must between 0.0 and 10.0")]
    public decimal Rating { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime ReleaseDate { get; set; }
    public int DirectorId { get; set; }
}
