namespace RotsPapierSchaar.Contracts.Responses;

public record RondeResultaatResponse(
    int RondeNummer,
    string SpelerZet,
    string ComputerZet,
    string Uitslag,
    bool SpelIsKlaar
);
