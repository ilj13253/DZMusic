namespace Model.SoundWave.Entities;

public class Song
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string SongURL { get; set; }
}