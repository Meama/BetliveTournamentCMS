using Application.DTO;
using MediatR;

namespace Application.Icons.Queries.GetIcons;

public class GetIconsQuery : IRequest<IconsDto>
{
}