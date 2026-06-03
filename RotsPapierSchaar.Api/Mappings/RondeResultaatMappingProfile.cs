using Mapster;
using RotsPapierSchaar.Application.Dtos;
using RotsPapierSchaar.Contracts.Responses;

namespace RotsPapierSchaar.Api.Mappings;

public class RondeResultaatMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RondeResultaatDto, RondeResultaatResponse>();
    }
}
