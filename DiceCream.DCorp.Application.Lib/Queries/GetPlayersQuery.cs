namespace DiceCream.DCorp.Application.Queries;

public record GetPlayersQuery() : IRequest<IEnumerable<PlayerDTO>>;