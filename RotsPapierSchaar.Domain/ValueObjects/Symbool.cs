namespace RotsPapierSchaar.Domain.ValueObjects;

public abstract class Symbool
{
    public abstract string Naam { get; }
    public abstract bool WintTegen(Symbool ander);
}
