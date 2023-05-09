﻿using MediatR;

namespace Application.Identity.Commands.AddUser;

public class AddUserCommand : IRequest
{
    public string Email { get; set; }

    public string Password { get; set; }

    public List<string> Roles { get; set; }
}