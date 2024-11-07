namespace DiceCream.DCorp.Application.Lib.Handlers;

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
        if(player == null)
        {
            return null;
        }

        var playerDto = new PlayerDTO
        {
            Id = player.Id,
            Nickname = player.Nickname,
            Level = player.Level,
            Xp = player.Xp,
            AcquiredSkills = player.PlayerSkills.Select(ps => new SkillDTO
            {
                Id = ps.Skill.Id,
                Name = ps.Skill.Name,
                Effect = ps.Skill.Effect,
                IsPermanent = ps.Skill.IsPermanent
            }).ToList()
        };

        return playerDto;
    }
}
