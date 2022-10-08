namespace Digimon.Api.Constracts.Responses;

public class TamerResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<string> Pictures { get; set; } = new List<string>();
    
    public string Gender { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public int Birthyear { get; set; }
    public string BloodType { get; set; } = string.Empty;
    
    public List<string> Traits { get; set; } = new List<string>();
    
    public List<string> Partner { get; set; } = new List<string>();
    public List<string> Digivices { get; set; } = new List<string>(); 

    public List<string> AppearsIn { get; set; } = new List<string>();
    public string FirstAppearance { get; set; } = string.Empty;
    public string LatestAppearance { get; set; } = string.Empty;
}