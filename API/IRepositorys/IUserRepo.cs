
using Infrastructure.EntityRequest;
using Infrastructure.Models.Entitis;

namespace API.IRepositorys
{
    public interface IUserRepo
    {
        List<User> GetAllUser();
        User GetById(Guid id);
        User CreateUser(UserRequest u);
        User UpdateUser(Guid id, User u);
        User DeleteUser(Guid id);
        bool UserExists(string userName);
    }
}
