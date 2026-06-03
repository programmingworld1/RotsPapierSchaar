using Mapster;
using RotsPapierSchaar.Application.Dtos;
using RotsPapierSchaar.Contracts.Requests;

namespace RotsPapierSchaar.Api.Mapping;

public class StartSpelRequestMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<StartSpelRequest, StartSpelDto>();
    }
}
