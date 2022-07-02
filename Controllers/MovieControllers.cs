using  Movie.Data ;
using Microsoft.EntityFrameworkCore;
using Movie.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Movie.Controllers;
[ApiController]
[Route("[controller]")]
public class MovieControllers:ControllerBase
{
    private readonly ILogger _logger;
    private readonly AppDbContext _context;
    public MovieControllers(ILogger<MovieControllers> logger,AppDbContext context)
    {
        _context=context;
        _logger=logger;
    }
    [HttpGet]
     public async  Task<IActionResult> Get (){
      return Ok( await _context.Movie.ToListAsync());
    }
     
    [HttpGet]
    [Route("{Id}")]
    public async Task<IActionResult> Get(Guid Id){
        var movie=await _context.Movie.FirstOrDefaultAsync(s=>s.Id==Id);
        movie.Viewed++;
        _context.Movie.Update(movie);
       await _context.SaveChangesAsync();
        return Ok(movie);
    }
    [HttpPost]
    public async Task<IActionResult> Post(Movies movies)
    {
        await _context.AddAsync(movies);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Created),movies);
    }
    [HttpDelete]
    [Route("{Id}")]
    public async Task<IActionResult> Delete(Guid Id){
         var movie=await _context.Movie.FirstOrDefaultAsync(s=>s.Id==Id);
        _context.Movie.Remove(movie);
         await _context.SaveChangesAsync();

        
        return Ok("Successfully deleted");
    }
}