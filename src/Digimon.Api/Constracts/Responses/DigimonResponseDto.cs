namespace Digimon.Api.Constracts.Responses;

public class DigimonResponseDto
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public IEnumerable<string> Pictures { get; set; } = new List<string>();

    public string Level { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;
    public IEnumerable<string> Attributes { get; set; } = new List<string>();
    public IEnumerable<string> Families { get; set; } = new List<string>();
    public string Size { get; set; } = string.Empty;
    public IEnumerable<string> PrioForms { get; set; } = new List<string>();
    public IEnumerable<string> NextForms { get; set; } = new List<string>();
    public IEnumerable<string> Partners { get; set; } = new List<string>();
    
}