namespace Entities;
public class MovieDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Rating { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
