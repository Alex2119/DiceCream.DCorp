using DiceCream.DCorp.Application.Queries;
using DiceCream.DCorp.Infrastructure.Models;

namespace DiceCream.DCorp.Application.Handlers;
public class GetPlayersQueryHandler : IRequestHandler<GetPlayersQuery, IEnumerable<PlayerDTO>>
{
    private readonly IRepository _repository;
    public GetPlayersQueryHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PlayerDTO>> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetPlayers();
    }
}
