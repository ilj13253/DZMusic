using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.SoundWave.Entities;

namespace Model.SoundWave.Data;
public class SoundWaveDBContext(DbContextOptions<SoundWaveDBContext> options) : IdentityDbContext(options)
{
    public DbSet<Album> Albums { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public new DbSet<User> Users { get; set; }
    public DbSet<FeaturedSong> FeaturedSongs { get; set; }
}