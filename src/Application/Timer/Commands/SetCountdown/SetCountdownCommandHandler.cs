using MediatR;
using Application.Options;
using Application.Timer.Models;
using Microsoft.Extensions.Options;
using Meama.Common.Settings.Abstractions;

namespace Application.Timer.Commands.SetCountdown;

public class SetCountdownCommandHandler : IRequestHandler<SetCountdownCommand>
{
    private readonly ISettingService _setting;
    private readonly IOptions<SettingeServiceOptions> _settingeServiceOptions;

    public SetCountdownCommandHandler(ISettingService setting, IOptions<SettingeServiceOptions> settingeServiceOptions)
    {
        _setting = setting;
        _settingeServiceOptions = settingeServiceOptions;
    }

    public async Task<Unit> Handle(SetCountdownCommand request, CancellationToken cancellationToken)
    {
        var model = new CountdownModel
        {
            TimeInMinutes = request.TimeInMinutes,
            SaveTime = DateTime.UtcNow
        };

        await _setting.DeleteSettingAsync(_settingeServiceOptions.Value.TimerKey, cancellationToken);
        await _setting.SetSettingAsync(_settingeServiceOptions.Value.TimerKey, model, cancellationToken);

        return Unit.Value;
    }
}