using RotsPapierSchaar.Domain.Entities;

namespace RotsPapierSchaar.Application.InfraServices;

public interface ISpelRepository
{
    Spel? HaalSpelOp();
    void OpslaanSpel(Spel spel);
}
