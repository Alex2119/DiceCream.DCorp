
namespace DiceCream.DCorp.Application.Lib.Queries;

public record GetPlayerQuery(int PlayerId) : IRequest<PlayerDTO>;

