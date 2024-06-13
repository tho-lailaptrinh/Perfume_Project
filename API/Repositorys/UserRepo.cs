
using API.IRepositorys;
using Infrastructure.EntityRequest;
using Infrastructure.Models.Data;
using Infrastructure.Models.Entitis;
using Microsoft.EntityFrameworkCore;

namespace API.Repositorys
{
    public class UserRepo : IUserRepo
    {
        private MyDbContext _context;
        public UserRepo(MyDbContext context)
        {
            _context = context;
        }
        public List<User> GetAllUser()
        {
            var data =  _context.Users.ToList();
            return data;
        }
        public User CreateUser(UserRequest u)
        {
            User user = new User()
            {
                Name = u.Name,
                UserName = u.UserName,
                Password = u.Password,
                PhoneNumber = u.PhoneNumber,
                Address = u.Address,
                Dob = u.Dob,
                Role = u.Role,
                Id = Guid.NewGuid()
            };
            var gh = new GioHang()
            {
                Id = user.Id,
            };
            _context.Users.Add(user);
            _context.GioHangs.Add(gh);
             _context.SaveChanges();
            return user;
        }

        public User UpdateUser(Guid id, User u)
        {
            try
            {
                var bom =  _context.Users.FirstOrDefault(x => x.Id == id);
                bom.Name = u.Name;
                bom.UserName = u.UserName;
                bom.Password = u.Password;
                bom.PhoneNumber = u.PhoneNumber;
                bom.Address = u.Address;
                bom.Dob = u.Dob;
                bom.Role = u.Role;
                _context.Users.Update(bom);
                 _context.SaveChanges();
                return bom;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User DeleteUser(Guid id)
        {
                var bom =  _context.Users.FirstOrDefault(x => x.Id == id);
                _context.Users.Remove(bom);
                 _context.SaveChanges();
                return bom;
           
        }

        public  User GetById(Guid id)
        {
            var getId =  _context.Users.Find(id);
            return getId;
        }

        public bool UserExists(string userName)
        {
            return  _context.Users.Any(x => x.UserName == userName);
        }
    }
}
