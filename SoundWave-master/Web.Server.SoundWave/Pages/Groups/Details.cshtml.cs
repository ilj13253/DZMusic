using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.SoundWave.Data;
using Model.SoundWave.Entities;

namespace Web.Server.SoundWave.Pages.Groups;

public class DetailsModel(SoundWaveDBContext soundWaveDBContext) : PageModel
{
    public Group? Group { get; set; }
    public IEnumerable<Album>? Albums { get; set; }

    public async Task OnGet(int id)
    {
        Group = await soundWaveDBContext.Groups.SingleAsync(group => group.Id == id);

        Albums = soundWaveDBContext.Albums
            .Include(album => album.Groups)
            .Include(album => album.Songs)
            .Where(album => album.Groups.Contains(Group));
    }
}