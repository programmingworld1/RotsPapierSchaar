using RotsPapierSchaar.Domain.ValueObjects;

namespace RotsPapierSchaar.Domain.Entities;

public class Spel
{
    private readonly List<Ronde> _rondes = [];

    public int DoelAantalRondes { get; }
    public IReadOnlyList<Ronde> Rondes { get { return _rondes.AsReadOnly(); } }

    public Spel(int doelAantalRondes)
    {
        DoelAantalRondes = doelAantalRondes;
    }

    public Ronde SpeelRonde(Symbool spelerZet, Symbool computerZet)
    {
        var ronde = new Ronde(_rondes.Count + 1, spelerZet, computerZet);

        _rondes.Add(ronde);
        return ronde;
    }

    public bool IsKlaar()
    {
        return _rondes.Count >= DoelAantalRondes;
    }
}
