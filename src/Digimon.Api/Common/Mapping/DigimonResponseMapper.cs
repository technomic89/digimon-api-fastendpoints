using Digimon.Api.Constracts.Responses;

namespace Digimon.Api.Common.Mapping;

public static class DigimonResponseMapper
{
    /// <summary>
    ///     Map Digimon from Entity to Dto
    /// </summary>
    /// <param name="d"><see cref="Domain.Entities.Digimon"/></param>
    /// <returns><see cref="DigimonResponseDto"/></returns>
    public static DigimonResponseDto FromEntity(this Domain.Entities.Digimon d) => new()
    {
        Id = d.Id,
        Name = d.Name,
        Level = GetDigimonLevel(d.LevelId),
        Size = d.Size,
        Pictures = d.DigimonPictures.Select(p => p.Picture).ToList()
    };

    /// <summary>
    ///     Map list of Digimon from Entity to Dto
    /// </summary>
    /// <param name="digimon"><see cref="IEnumerable{T}"/> - List of Digimon Entity</param>
    /// <returns><see cref="IEnumerable{T}"/> - List of Digimon Dto</returns>
    public static IEnumerable<DigimonResponseDto> FromListEntity(this IEnumerable<Domain.Entities.Digimon> digimon)
    {
        return digimon.Select(d => d.FromEntity()).ToList();
    }
    
    /// <summary>
    ///     Get Digimon Level
    /// </summary>
    /// <param name="levelId"><see cref="int"/> - The Level-Id</param>
    /// <returns><see cref="string"/> - The Name of the Level</returns>
    private static string GetDigimonLevel(int levelId)
    {
        return levelId switch
        {
            0 => "Digi Egg",
            1 => "Baby I",
            2 => "Baby II",
            3 => "Rookie",
            4 => "Champion",
            5 => "Ultra",
            6 => "Mega",
            7 => "Armor",
            8 => "Hybrid",
            9 => "Super-Mega",
            _ => ""
        };
    }
}