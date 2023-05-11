using MediatR;
using Application.DTO;
using Application.Options;
using Application.Healper;
using Microsoft.Extensions.Options;
using Meama.Common.Settings.Abstractions;

namespace Application.Icons.Queries.GetIcons;

public class GetIconsQueryHandler : IRequestHandler<GetIconsQuery, IconsDto>
{
    private readonly ISettingService _setting;
    private readonly IOptions<SettingeServiceOptions> _settingeServiceOptions;

    public GetIconsQueryHandler(ISettingService setting, IOptions<SettingeServiceOptions> settingeServiceOptions)
    {
        _setting = setting;
        _settingeServiceOptions = settingeServiceOptions;
    }

    public async Task<IconsDto> Handle(GetIconsQuery request, CancellationToken cancellationToken)
    {
        return new IconsDto
        {
            LoserIcon = await _setting.GetSettingByKeyAsync<string>(_settingeServiceOptions.Value.LoserIconKey, cancellationToken).ConvertExeption(_settingeServiceOptions.Value.LoserIconKey),
            WinnerIcon = await _setting.GetSettingByKeyAsync<string>(_settingeServiceOptions.Value.WinnerIconKey, cancellationToken).ConvertExeption(_settingeServiceOptions.Value.WinnerIconKey),
            BetliveIcon = await _setting.GetSettingByKeyAsync<string>(_settingeServiceOptions.Value.BetliveIconKey, cancellationToken).ConvertExeption(_settingeServiceOptions.Value.BetliveIconKey)
        };
    }
}