using RotsPapierSchaar.Application.InfraServices;
using RotsPapierSchaar.Domain.ValueObjects;

namespace RotsPapierSchaar.Infrastructure.Generators;

public class ComputerZetGenerator : IComputerZetGenerator
{
    private static readonly Random _random = Random.Shared;
    private static readonly Symbool[] _symbolen = [new Rots(), new Papier(), new Schaar()];

    public Symbool GenereerZet()
    {
        return _symbolen[_random.Next(_symbolen.Length)];
    }
}
