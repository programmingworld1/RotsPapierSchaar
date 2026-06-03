namespace RotsPapierSchaar.Contracts.Responses;

public record SpelSamenvattingResponse(
    int AantalGespeeldeRondes,
    int SpelerOverwinningen,
    int ComputerOverwinningen,
    int Gelijkspellen,
    string Winnaar
);
