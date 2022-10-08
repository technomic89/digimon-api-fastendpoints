namespace Digimon.Domain.Entities;

public class DigimonPictures
{
    public int Id { get; set; }
    
    public int DigimonId { get; set; }
    public string Picture { get; set; } = string.Empty;

    public virtual Digimon Digimon { get; set; } = null!;
}