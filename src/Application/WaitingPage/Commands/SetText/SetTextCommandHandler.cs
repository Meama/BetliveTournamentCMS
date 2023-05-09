using MediatR;
using Application.Options;
using Microsoft.Extensions.Options;
using Meama.Common.Settings.Abstractions;

namespace Application.WaitingPage.Commands.SetText;

public class SetTextCommandHandler : IRequestHandler<SetTextCommand>
{
    private readonly ISettingService _setting;
    private readonly IOptions<SettingeServiceOptions> _settingeServiceOptions;

    public SetTextCommandHandler(ISettingService setting, IOptions<SettingeServiceOptions> settingeServiceOptions)
    {
        _setting = setting;
        _settingeServiceOptions = settingeServiceOptions;
    }

    public async Task<Unit> Handle(SetTextCommand request, CancellationToken cancellationToken)
    {
        await _setting.DeleteSettingAsync(_settingeServiceOptions.Value.WaitingPageTextKey, cancellationToken);
        await _setting.SetSettingAsync(_settingeServiceOptions.Value.WaitingPageTextKey, request.Text, cancellationToken);

        return Unit.Value;
    }
}