using System.ComponentModel.DataAnnotations;

namespace Entities;
public class DirectorForManipulationDto
{
    [Required(ErrorMessage = "Director name is required field")]
    public string? Name { get; set; }
}
