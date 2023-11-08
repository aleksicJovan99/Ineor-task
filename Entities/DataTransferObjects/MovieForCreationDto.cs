using System.ComponentModel.DataAnnotations;

namespace Entities;
public class MovieForCreationDto
{
    public string Name { get; set; }
    public decimal Rating { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime ReleaseDate { get; set; }
    public int DirectorId { get; set; }
}
