using RotsPapierSchaar.Domain.ValueObjects;

namespace RotsPapierSchaar.Application.InfraServices;

public interface IComputerZetGenerator
{
    Symbool GenereerZet();
}
