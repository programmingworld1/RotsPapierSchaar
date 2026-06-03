namespace RotsPapierSchaar.Application.Dtos;

public record SpelSamenvattingDto(
    int AantalGespeeldeRondes,
    int SpelerOverwinningen,
    int ComputerOverwinningen,
    int Gelijkspellen,
    string Winnaar
);
