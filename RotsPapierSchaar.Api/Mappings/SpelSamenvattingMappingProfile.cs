using Mapster;
using RotsPapierSchaar.Application.Dtos;
using RotsPapierSchaar.Contracts.Responses;

namespace RotsPapierSchaar.Api.Mappings;

public class SpelSamenvattingMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<SpelSamenvattingDto, SpelSamenvattingResponse>();
    }
}
