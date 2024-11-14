using DiceCream.DCorp.Application.Extensions;
using DiceCream.DCorp.Application.Queries;

namespace DiceCream.DCorp.Application.Handlers;

public class GetPlayerQueryHandler : IRequestHandler<GetPlayerQuery, PlayerDTO>
{
    private readonly IRepository _playerRepository;

    public GetPlayerQueryHandler(IRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<PlayerDTO> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
    {
        var player = await _playerRepository.GetPlayerByIdAsync(request.PlayerId);
        if(player is null)
        {
            return null;
        }
        return player.ToDTO();
    }
}
