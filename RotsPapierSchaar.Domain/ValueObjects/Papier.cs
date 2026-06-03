namespace RotsPapierSchaar.Domain.ValueObjects;

public class Papier : Symbool
{
    public const string NaamWaarde = "Papier";
    public override string Naam { get { return NaamWaarde; } }

    public override bool WintTegen(Symbool ander)
    {
        return ander is Rots;
    }
}
