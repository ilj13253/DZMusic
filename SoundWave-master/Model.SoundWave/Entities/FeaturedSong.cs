namespace Model.SoundWave.Entities;
public class FeaturedSong
{
    public int Id { get; set; }
    public required User user { get; set; }
    public required Song song { get; set; }
}