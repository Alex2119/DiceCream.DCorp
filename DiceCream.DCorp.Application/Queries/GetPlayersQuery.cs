using DiceCream.DCorp.Domain.Entities;
using MediatR;

namespace DiceCream.DCorp.Application.Queries;

public record GetPlayersQuery() : IRequest<IEnumerable<Player>>;