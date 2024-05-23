﻿using AspDotNet_MVC.IRepositorys;
using AspDotNet_MVC.Models.Data;
using AspDotNet_MVC.Models.Entitis;
using Microsoft.EntityFrameworkCore;

namespace AspDotNet_MVC.Repositorys
{
    public class UserRepo : IUserRepo
    {
        private MyDbContext _context;
        public UserRepo(MyDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUser()
        {
            var data = await _context.Users.ToListAsync();
            return data;
        }
        public async Task<User> CreateUser(User u)
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
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(Guid id, User u)
        {
            try
            {
                var bom = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                bom.Name = u.Name;
                bom.UserName = u.UserName;
                bom.Password = u.Password;
                bom.PhoneNumber = u.PhoneNumber;
                bom.Address = u.Address;
                bom.Dob = u.Dob;
                bom.Role = u.Role;
                _context.Users.Update(bom);
                await _context.SaveChangesAsync();
                return bom;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> DeleteUser(Guid id)
        {
                var bom = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                _context.Users.Remove(bom);
                await _context.SaveChangesAsync();
                return bom;
           
        }

        public  async Task<User> GetById(Guid id)
        {
            var getId = await _context.Users.FindAsync(id);
            return getId;
        }

        public async Task<bool> UserExists(string userName)
        {
            return await _context.Users.AnyAsync(x => x.UserName == userName);
        }
    }
}
