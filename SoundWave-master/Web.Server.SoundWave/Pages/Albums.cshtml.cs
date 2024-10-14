using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.SoundWave.Data;
using Model.SoundWave.Entities;

namespace Web.Server.SoundWave.Pages;

public class AlbumsModel(SoundWaveDBContext soundWaveDBContext) : PageModel
{
    public IEnumerable<Album>? Albums { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public string? TitleSearchString { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public string? GenreSearchString { get; set; }
    
    public SelectList? Genres { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public decimal? MinPrice { get; set; }

    [BindProperty(SupportsGet = true)]
    public decimal? MaxPrice { get; set; }
    public void OnGet()
    {
        Albums = soundWaveDBContext.Albums;
        /*
        var albums = soundWaveDBContext.Albums.AsQueryable();

        // Filter by price range if both MinPrice and MaxPrice are set
        if (MinPrice.HasValue && MaxPrice.HasValue)
        {
            albums = albums.Where(album => album.Price >= MinPrice.Value && album.Price <= MaxPrice.Value);
        }

        Albums = albums;
        */
        var albums = soundWaveDBContext.Albums.AsQueryable();
        if (!string.IsNullOrEmpty(TitleSearchString))
        {
            albums = albums.Where(album => album.Title.ToUpper().Contains(TitleSearchString.ToUpper()));
        }

        // Filtering by Genre
        if (!string.IsNullOrEmpty(GenreSearchString))
        {
            albums = albums.Where(album => album.Genres.Any(genre => genre.Title.ToUpper().Contains(GenreSearchString.ToUpper())));
        }

        Genres = new SelectList(soundWaveDBContext.Genres.Select(genre => genre.Title));

        Albums = albums;
    }
}