using System.ComponentModel.DataAnnotations;
namespace Movie.Entity;
 public class Movies
{
    [Key]
   public Guid Id { get; set; } 
    [Required]   
    public string?  Title { get; set; }

    public DateTime ReleaseDate { get; set; }
    [Required]

    public EGenres  Genre { get; set; }
    public string? Description { get; set; }
    [Required]
    public double Imdb { get; set; }
    public ulong Viewed { get; set; }
}