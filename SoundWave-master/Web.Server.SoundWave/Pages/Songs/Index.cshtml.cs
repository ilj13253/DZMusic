using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.SoundWave.Data;
using Model.SoundWave.Entities;

namespace Web.Server.SoundWave.Pages.Songs;


public enum FilteredValues
{
    Asc,
    Desc
}

public class IndexModel(SoundWaveDBContext soundWaveDBContext) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? NameSearchString { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? GenreSearchString {  get; set; }

    [BindProperty(SupportsGet = true)]
    public FilteredValues? FilteredValue { get; set; }

    public SelectList? Genres { get; set; }
    public IEnumerable<Song>? Songs { get; set; }
    public void OnGet()
    {
        var songs = soundWaveDBContext.Songs.AsQueryable();

        if (!string.IsNullOrEmpty(NameSearchString))
        {
            songs = songs.Where(song => song.Title.ToUpper().Contains(NameSearchString.ToUpper()));
        }

        songs = FilteredValue switch
        {
            FilteredValues.Asc => songs.OrderBy(song => song.Title),
            FilteredValues.Desc => songs.OrderByDescending(song => song.Title),
            _ => songs
        };

        Genres = new(soundWaveDBContext.Genres.Select(genre => genre.Title));

        Songs = songs;
    }
}
