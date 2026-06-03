using RotsPapierSchaar.Application.InfraServices;
using RotsPapierSchaar.Domain.Entities;

namespace RotsPapierSchaar.Infrastructure.Repositories;

public class InMemorySpelRepository : ISpelRepository
{
    private Spel? _spel;

    public Spel? HaalSpelOp()
    {
        return _spel;
    }

    public void OpslaanSpel(Spel spel)
    {
        _spel = spel;
    }
}
