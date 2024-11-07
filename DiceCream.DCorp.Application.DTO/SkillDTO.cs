namespace DiceCream.DCorp.Application.DTO;

// Après, c'est au choix. Pas obligé de le mettre dans nom car le namespace est là.
// Comme pour les DAO enfaite.
public class SkillDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Effect { get; set; }
    public bool IsPermanent { get; set; }
}
