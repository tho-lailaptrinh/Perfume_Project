
using Infrastructure.Models.Entitis;

namespace Infrastructure.IRepositorys
{
    public interface IUserRepo
    {
        Task<List<User>> GetAllUser();
        Task<User> GetById(Guid id);
        Task<User> CreateUser(User u);
        Task<User> UpdateUser(Guid id, User u);
        Task<User> DeleteUser(Guid id);
        Task<bool> UserExists(string userName);
    }
}
