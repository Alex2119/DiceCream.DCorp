using DiceCream.DCorp.Infrastructure.Models;

namespace DiceCream.DCorp.Application.Services;

public interface IUserRoleService
{
    Task AssignRoleAndProfileAsync(User user, string roleName);
}
