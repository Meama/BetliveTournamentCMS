using MediatR;

namespace Application.Identity.Queries.GetAllRolesWithClames;

public class GetAllRolesWithClamesQuery : IRequest<Dictionary<string, string[]>>
{
}