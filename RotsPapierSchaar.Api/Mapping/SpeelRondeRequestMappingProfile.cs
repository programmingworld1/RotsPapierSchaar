using Mapster;
using RotsPapierSchaar.Application.Dtos;
using RotsPapierSchaar.Contracts.Requests;

namespace RotsPapierSchaar.Api.Mapping;

public class SpeelRondeRequestMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<SpeelRondeRequest, SpeelRondeDto>();
    }
}
