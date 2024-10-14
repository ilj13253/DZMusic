using Model.SoundWave.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.SoundWave.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace Web.Server.SoundWave.Pages.Groups;

public class IndexModel(SoundWaveDBContext soundWaveDBContext) : PageModel
{
    public IEnumerable<Group>? Groups { get; set; }
    [BindProperty(SupportsGet = true)]
    public string? TitleSearchString { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? GenreSearchString { get; set; }

    public SelectList? Genres { get; set; }
    public void OnGet()
    {
        Groups = soundWaveDBContext.Groups;
        
    }
}