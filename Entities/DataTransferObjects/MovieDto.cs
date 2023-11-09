using System.ComponentModel.DataAnnotations;

namespace Entities;
public class MovieDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Rating { get; set; }
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime ReleaseDate { get; set; }
}
