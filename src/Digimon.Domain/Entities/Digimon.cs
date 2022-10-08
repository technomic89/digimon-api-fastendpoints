namespace Digimon.Domain.Entities;

public sealed class Digimon
{
    public Digimon()
    {
        DigimonPictures = new HashSet<DigimonPictures>();
    }
    
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public int LevelId { get; set; }
    
    public string Size { get; set; } = string.Empty;

    public ICollection<DigimonPictures> DigimonPictures { get; set; }
}