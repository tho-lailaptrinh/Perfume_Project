
using Infrastructure.Models.Entitis;

namespace Infrastructure.EntityRequest
{
    public class UserRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
        public string? Role { get; set; }
        public virtual ICollection<HoaDon>? HoaDons { get; set; }

        //public Guid IdGH { get; set; }
        public virtual GioHang? GioHangs { get; set; }
    }
}
