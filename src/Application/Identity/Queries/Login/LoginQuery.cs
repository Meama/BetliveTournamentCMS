using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Queries.Login;

public class LoginQuery : IRequest<LoginDto>
{
    public string Email { get; set; }

    public string Password { get; set; }
}