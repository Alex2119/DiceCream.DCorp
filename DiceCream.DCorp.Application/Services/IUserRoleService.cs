using DiceCream.DCorp.Domain.Entities;

namespace DiceCream.DCorp.Application.Services
{
    public interface IUserRoleService
    {
        Task AssignRoleAndProfileAsync(User user, string roleName);
    }
}
