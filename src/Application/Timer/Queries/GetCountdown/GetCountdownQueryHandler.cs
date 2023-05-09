using MediatR;
using Application.Options;
using Application.Healper;
using Application.Timer.Models;
using Microsoft.Extensions.Options;
using Meama.Common.Settings.Abstractions;

namespace Application.Timer.Queries.GetCountdown;


public class GetCountdownQueryHandler : IRequestHandler<GetCountdownQuery, int>
{
    private readonly ISettingService _setting;
    private readonly IOptions<SettingeServiceOptions> _settingeServiceOptions;

    public GetCountdownQueryHandler(ISettingService setting, IOptions<SettingeServiceOptions> settingeServiceOptions)
    {
        _setting = setting;
        _settingeServiceOptions = settingeServiceOptions;
    }

    public async Task<int> Handle(GetCountdownQuery request, CancellationToken cancellationToken)
    {
        var countdownModel = await _setting.GetSettingByKeyAsync<CountdownModel>(_settingeServiceOptions.Value.TimerKey, cancellationToken).ConvertExeption(_settingeServiceOptions.Value.TimerKey);

        var secondsAfterSaveCountdown = (int)(DateTime.UtcNow - countdownModel.SaveTime).TotalSeconds;
        var result = countdownModel.TimeInMinutes * 60 - secondsAfterSaveCountdown;

        return result;
    }
}