using RotsPapierSchaar.Domain.ValueObjects;

namespace RotsPapierSchaar.Domain.Factories;

public static class SymboolFactory
{
    public static Symbool? Create(string naam)
    {
        if (naam.Equals(Rots.NaamWaarde, StringComparison.OrdinalIgnoreCase))
        {
            return new Rots();
        }

        if (naam.Equals(Papier.NaamWaarde, StringComparison.OrdinalIgnoreCase))
        {
            return new Papier();
        }

        if (naam.Equals(Schaar.NaamWaarde, StringComparison.OrdinalIgnoreCase))
        {
            return new Schaar();
        }

        return null;
    }
}
