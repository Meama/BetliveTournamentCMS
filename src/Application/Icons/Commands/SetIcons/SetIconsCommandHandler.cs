using MediatR;
using Application.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Infrastructure.Image.Abstraction;
using Meama.Common.Settings.Abstractions;

namespace Application.Icons.Commands.SetIcons;

public class SetIconsCommandHandler : IRequestHandler<SetIconsCommand>
{
    private readonly IImageUploadService _imageUpload;
    private readonly ISettingService _setting;
    private readonly IOptions<SettingeServiceOptions> _settingeServiceOptions;

    public SetIconsCommandHandler(IImageUploadService imageUpload, ISettingService setting, IOptions<SettingeServiceOptions> settingeServiceOptions)
    {
        _setting = setting;
        _imageUpload = imageUpload;
        _settingeServiceOptions = settingeServiceOptions;
    }

    public async Task<Unit> Handle(SetIconsCommand request, CancellationToken cancellationToken)
    {
        await UploadImageIfExistAsync(request.LoserIcon, _settingeServiceOptions.Value.LoserIconKey, cancellationToken);

        await UploadImageIfExistAsync(request.WinnerIcon, _settingeServiceOptions.Value.WinnerIconKey, cancellationToken);

        await UploadImageIfExistAsync(request.BetliveIcon, _settingeServiceOptions.Value.BetliveIconKey, cancellationToken);

        return Unit.Value;
    }

    public async Task UploadImageIfExistAsync(IFormFile formFile, string key, CancellationToken cancellationToken)
    {
        if (formFile == null) return;

        var iconUrl = await _imageUpload.UploadImageAsync(formFile);
        await _setting.DeleteSettingAsync(key, cancellationToken);
        await _setting.SetSettingAsync(key, iconUrl, cancellationToken);
    }
}