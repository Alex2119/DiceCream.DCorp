namespace DiceCream.DCorp.Application.Lib.Services;

public interface IUserRoleService
{
    Task AssignRoleAndProfileAsync(User user, string roleName);
}
