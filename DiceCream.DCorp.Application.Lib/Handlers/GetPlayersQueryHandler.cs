using DiceCream.DCorp.Application.Queries;

namespace DiceCream.DCorp.Application.Handlers;
public class GetPlayersQueryHandler : IRequestHandler<GetPlayersQuery, IEnumerable<Player>>
{
    private readonly IRepository _repository;
    public GetPlayersQueryHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Player>> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetPlayers();
    }
}
