using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.SoundWave.Data;
using Model.SoundWave.Entities;

namespace Web.Server.SoundWave.Pages;

public class AlbumDetailsModel(SoundWaveDBContext soundWaveDBContext) : PageModel
{
    public Album? Album { get; set; }
    public async Task OnGetAsync(int id)
    {
        Album = await soundWaveDBContext.Albums
            .Include(album => album.Songs)
            .Include(album => album.Groups)
            .SingleAsync(album => album.Id == id);
    }
}