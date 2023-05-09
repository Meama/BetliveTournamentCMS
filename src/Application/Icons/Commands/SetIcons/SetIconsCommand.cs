using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Icons.Commands.SetIcons;

public class SetIconsCommand : IRequest
{
    public IFormFile LoserIcon { get; set; }

    public IFormFile WinnerIcon { get; set; }

    public IFormFile BetliveIcon { get; set; }
}