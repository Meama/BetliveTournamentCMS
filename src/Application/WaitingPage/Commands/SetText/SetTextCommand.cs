using MediatR;

namespace Application.WaitingPage.Commands.SetText;

public class SetTextCommand : IRequest
{
    public string Text { get; set; }
}