namespace RotsPapierSchaar.Application.Dtos;

public record RondeResultaatDto(
    int RondeNummer,
    string SpelerZet,
    string ComputerZet,
    string Uitslag,
    bool SpelIsKlaar
);
