using MediatR;
using Application.Options;
using Application.Healper;
using Microsoft.Extensions.Options;
using Meama.Common.Settings.Abstractions;

namespace Application.WaitingPage.Queries.GetText;

public class GetTextQueryHandler : IRequestHandler<GetTextQuery, string>
{
    private readonly ISettingService _setting;
    private readonly IOptions<SettingeServiceOptions> _settingeServiceOptions;

    public GetTextQueryHandler(ISettingService setting, IOptions<SettingeServiceOptions> settingeServiceOptions)
    {
        _setting = setting;
        _settingeServiceOptions = settingeServiceOptions;
    }

    public async Task<string> Handle(GetTextQuery request, CancellationToken cancellationToken)
    {
        var text = await _setting.GetSettingByKeyAsync<string>(_settingeServiceOptions.Value.WaitingPageTextKey, cancellationToken).ConvertExeption(_settingeServiceOptions.Value.WaitingPageTextKey);

        return text;
    }
}