using AspDotNet_MVC.IService;
using Infrastructure.EntityRequest;
using Infrastructure.Models.Entitis;
using Newtonsoft.Json;

namespace AspDotNet_MVC.Service
{
    public class UserService : IUserService
    {
        HttpClient _client;
        public UserService()
        {
            _client = new HttpClient();
        }
        public List<UserRequest> GetAllUser()
        {
            string requestURL = "https://localhost:7143/api/User/get_user";
            var response = _client.GetStringAsync(requestURL).Result;
            var data = JsonConvert.DeserializeObject<List<UserRequest>>(response);
            return data;
        }
        
        public bool CreateUser(UserRequest user)
        {
            string requestURL = "https://localhost:7143/api/User/create_user";
            var response = _client.PostAsJsonAsync(requestURL, user).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public bool UpdateUser(Guid id, UserRequest user)
        {
            string requestURL = $"https://localhost:7143/api/User/update_user?id={id}";
            var response = _client.PutAsJsonAsync(requestURL, user).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public bool DeleteUser(Guid id)
        {
            string requestURL = $"https://localhost:7143/api/User/delete_user?id={id}";
            var response = _client.DeleteAsync(requestURL).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        
        public bool Login(UserRequest ur)
        {
            string requestURL = $"https://localhost:7143/api/User/login";
            var respones = _client.PostAsJsonAsync(requestURL, ur).Result;
            if (respones.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public UserRequest GetByIdUser(Guid id)
        {
            string requestURL = $"https://localhost:7143/api/User/getbyid_user?id={id}";
            var response = _client.GetStringAsync(requestURL).Result;
            var data = JsonConvert.DeserializeObject<UserRequest>(response);
            return data;
        }
    }
}
