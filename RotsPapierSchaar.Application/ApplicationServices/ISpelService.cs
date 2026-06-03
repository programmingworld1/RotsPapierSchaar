using RotsPapierSchaar.Application.Dtos;
using RotsPapierSchaar.Application.ResultPattern;

namespace RotsPapierSchaar.Application.ApplicationServices;

public interface ISpelService
{
    Result StartNieuwSpel(StartSpelDto startSpelDto);
    Result<RondeResultaatDto> SpeelRonde(SpeelRondeDto speelRondeDto);
    SpelSamenvattingDto HaalSamenvattingOp();
    bool IsSpelKlaar();
}
