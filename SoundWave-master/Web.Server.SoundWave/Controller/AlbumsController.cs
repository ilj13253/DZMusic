using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.SoundWave.Data;
using Model.SoundWave.Entities;
using Web.Server.SoundWave.Pogination;
using X.PagedList;
namespace Web.Server.SoundWave.Controllerr
{
    public class AlbumsController : Controller
    {
        private readonly SoundWaveDBContext _context;

        public AlbumsController(SoundWaveDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? page)
        {
            int pageNumber = page ?? 1; // Номер страницы (если не задана, то 1)
            int pageSize = 10; // Количество элементов на странице

            var albums = _context.Albums.OrderBy(a => a.Title); // Сортируем по названию

            //var pagedAlbums = await albums.ToPagedListAsync(pageNumber, pageSize);

            //return View(pagedAlbums);
            var albums2 = _context.Albums.AsQueryable();

            // Реализация постраничного вывода
            var pagedAlbums = await PaginatedList<Album>.CreateAsync(albums2, pageNumber, pageSize);
            return View(pagedAlbums);
        }
    }
}
