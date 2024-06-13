using Infrastructure.EntityRequest;
using Infrastructure.Models.Entitis;

namespace AspDotNet_MVC.IService
{
    public interface IUserService
    {
        List<UserRequest> GetAllUser();
        bool CreateUser(UserRequest user);
        bool UpdateUser(Guid id,UserRequest user);
        bool DeleteUser(Guid id);  
        bool Login(UserRequest ur);
        UserRequest GetByIdUser(Guid id);
    }
}
