using Mapster;
using RotsPapierSchaar.Application.Dtos;
using RotsPapierSchaar.Contracts.Responses;

namespace RotsPapierSchaar.Api.Mapping;

public class SpelSamenvattingMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<SpelSamenvattingDto, SpelSamenvattingResponse>();
    }
}
