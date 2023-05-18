using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TurnamentResult.Commands.DeleteTurnamentResult;

public class DeleteTurnamentResultCommand : IRequest
{
    public int Id { get; set; }
}