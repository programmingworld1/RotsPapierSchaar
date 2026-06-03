namespace RotsPapierSchaar.Domain.ValueObjects;

public class Rots : Symbool
{
    public const string NaamWaarde = "Rots";
    public override string Naam { get { return NaamWaarde; } }

    public override bool WintTegen(Symbool ander)
    {
        return ander is Schaar;
    }
}
