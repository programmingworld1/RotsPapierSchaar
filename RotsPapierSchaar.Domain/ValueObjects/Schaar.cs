namespace RotsPapierSchaar.Domain.ValueObjects;

public class Schaar : Symbool
{
    public const string NaamWaarde = "Schaar";
    public override string Naam { get { return NaamWaarde; } }

    public override bool WintTegen(Symbool ander)
    {
        return ander is Papier;
    }
}
