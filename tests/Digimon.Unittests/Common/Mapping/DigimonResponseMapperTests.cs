using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using Digimon.Api.Common.Mapping;
using Digimon.Api.Constracts.Responses;


namespace Digimon.Unittests.Common.Mapping;

public class DigimonResponseMapperTests
{
    [Fact]
    public void FromEntityToDtoTests()
    {
        var entity = new Domain.Entities.Digimon();

        var r = entity.FromEntity();

        r.Should().NotBeNull();
        r.Should().BeOfType<DigimonResponseDto>();
    }
    
    [Fact]
    public void FromListEntityToListDtoTests()
    {
        var list = new List<Domain.Entities.Digimon>();
        var entity = new Domain.Entities.Digimon();
        list.Add(entity);

        var r = list.FromListEntity();

        var digimonResponseDtos = r.ToList();
        digimonResponseDtos.Should().NotBeNull();
        digimonResponseDtos.Should().BeOfType<List<DigimonResponseDto>>();
    }
}