using RotsPapierSchaar.Domain.Enums;
using RotsPapierSchaar.Domain.ValueObjects;

namespace RotsPapierSchaar.Domain.Entities;

public class Ronde
{
    public int Nummer { get; }
    public Symbool SpelerZet { get; }
    public Symbool ComputerZet { get; }
    public SpelUitslag Uitslag { get; }

    public Ronde(
        int nummer,
        Symbool spelerZet,
        Symbool computerZet)
    {
        Nummer = nummer;
        SpelerZet = spelerZet;
        ComputerZet = computerZet;
        Uitslag = BerekenUitslag(spelerZet, computerZet);
    }

    private static SpelUitslag BerekenUitslag(Symbool speler, Symbool computer)
    {
        if (speler.GetType() == computer.GetType())
        {
            return SpelUitslag.Gelijkspel;
        }

        return speler.WintTegen(computer) ? SpelUitslag.SpelerWint : SpelUitslag.ComputerWint;
    }
}
