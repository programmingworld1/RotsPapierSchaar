using RotsPapierSchaar.Application.ApplicationServices;
using RotsPapierSchaar.Application.Dtos;
using RotsPapierSchaar.Application.InfraServices;
using RotsPapierSchaar.Application.ResultPattern;
using RotsPapierSchaar.Domain.Entities;
using RotsPapierSchaar.Domain.Enums;
using RotsPapierSchaar.Domain.Factories;
using RotsPapierSchaar.Domain.ValueObjects;

namespace RotsPapierSchaar.Application.Services;

public class SpelService : ISpelService
{
    private readonly IComputerZetGenerator _computerZetGenerator;
    private readonly ISpelRepository _spelRepository;

    public SpelService(
        IComputerZetGenerator computerZetGenerator,
        ISpelRepository spelRepository)
    {
        _computerZetGenerator = computerZetGenerator;
        _spelRepository = spelRepository;
    }

    public Result StartNieuwSpel(StartSpelDto startSpelDto)
    {
        if (startSpelDto.AantalRondes <= 0)
        {
            return Result.Failure(new Error(ErrorCode.ValidationError, "Het aantal rondes moet groter zijn dan nul."));
        }

        _spelRepository.OpslaanSpel(new Spel(startSpelDto.AantalRondes));
        return Result.Success();
    }

    public Result<RondeResultaatDto> SpeelRonde(SpeelRondeDto speelRondeDto)
    {
        var spel = _spelRepository.HaalSpelOp();
        if (spel is null)
        {
            return Result<RondeResultaatDto>.Failure(new Error(ErrorCode.InvalidOperation, "Start eerst een nieuw spel via POST /api/spel/start."));
        }

        var spelerZet = SymboolFactory.Create(speelRondeDto.SpelerZet);
        if (spelerZet is null)
        {
            return Result<RondeResultaatDto>.Failure(new Error(ErrorCode.ValidationError, $"Ongeldig symbool '{speelRondeDto.SpelerZet}'. Kies uit: Rots, Papier of Schaar."));
        }

        var computerZet = _computerZetGenerator.GenereerZet();
        var ronde = spel.SpeelRonde(spelerZet, computerZet);

        _spelRepository.OpslaanSpel(spel);

        return Result<RondeResultaatDto>.Success(new RondeResultaatDto(
            RondeNummer: ronde.Nummer,
            SpelerZet: ronde.SpelerZet.Naam,
            ComputerZet: ronde.ComputerZet.Naam,
            Uitslag: ronde.Uitslag.ToString(),
            SpelIsKlaar: spel.IsKlaar()
        ));
    }

    public SpelSamenvattingDto HaalSamenvattingOp()
    {
        var spel = _spelRepository.HaalSpelOp();
        var rondes = spel?.Rondes ?? [];

        int spelerWins = rondes.Count(r => r.Uitslag == SpelUitslag.SpelerWint);
        int computerWins = rondes.Count(r => r.Uitslag == SpelUitslag.ComputerWint);
        int gelijks = rondes.Count(r => r.Uitslag == SpelUitslag.Gelijkspel);

        string winnaar = spelerWins > computerWins ? "Speler"
            : computerWins > spelerWins ? "Computer"
            : "Gelijkspel";

        return new SpelSamenvattingDto(
            AantalGespeeldeRondes: rondes.Count,
            SpelerOverwinningen: spelerWins,
            ComputerOverwinningen: computerWins,
            Gelijkspellen: gelijks,
            Winnaar: winnaar
        );
    }

    public bool IsSpelKlaar()
    {
        var spel = _spelRepository.HaalSpelOp();
        return spel is not null && spel.IsKlaar();
    }
}
