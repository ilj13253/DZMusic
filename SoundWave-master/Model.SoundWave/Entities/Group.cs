namespace Model.SoundWave.Entities;

public class Group
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required int YearFoundation { get; set; }
    public required string UrlPreviewImg { get; set; }
    public required List<Artist> Artists { get; set; }
    public required List<Album> Albums { get; set; }
    public required List<Genre> Genres { get; set; }
}