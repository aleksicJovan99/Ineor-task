using System.ComponentModel.DataAnnotations;

namespace Entities;
public class UserForRegistrationDto
{
    [Required(ErrorMessage = "Name is required")] 
    public string? FullName { get; set; }
    [Required(ErrorMessage = "Username is required")] 
    public string? UserName { get; set; } 
    [Required(ErrorMessage = "Password is required")] 
    public string? Password { get; set; }
    [Required(ErrorMessage = "Email is required")] 
    public string? Email { get; set; }
    public ICollection<string>? Roles { get; set; }
}
