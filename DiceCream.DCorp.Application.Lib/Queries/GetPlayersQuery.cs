namespace DiceCream.DCorp.Application.Lib.Queries;

public record GetPlayersQuery() : IRequest<IEnumerable<Player>>;