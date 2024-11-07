namespace DiceCream.DCorp.Application.Queries;

public record GetPlayerQuery(int PlayerId) : IRequest<PlayerDTO>;

