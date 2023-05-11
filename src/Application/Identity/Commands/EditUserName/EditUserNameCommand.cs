using MediatR;

namespace Application.Identity.Commands.EditUserName;

public class EditUserNameCommand : IRequest
{
    public string Email { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }
}