using AspDotNet_MVC.IService;
using Infrastructure.EntityRequest;
using Newtonsoft.Json;

namespace AspDotNet_MVC.Service
{
    public class SanPhamService : ISanPhamService
    {
        HttpClient _httpClient;
        public SanPhamService()
        {
            _httpClient = new HttpClient();
        }
        public List<SanPhamRequest> GetAllSP()
        {
            string requestURL = "https://localhost:7143/api/SanPham/get_sp";
            var respones = _httpClient.GetStringAsync(requestURL).Result;
            var data = JsonConvert.DeserializeObject<List<SanPhamRequest>>(respones);
            return data;
        }

        public SanPhamRequest GetByIdSP(Guid id)
        {
            string requestURL = $"https://localhost:7143/api/SanPham/getbyid_sp?id={id}";
            var respones = _httpClient.GetStringAsync(requestURL).Result;
            var data = JsonConvert.DeserializeObject<SanPhamRequest>(respones);
            return data;
        }

        public bool CreateSP(SanPhamRequest request )
        {
            string requestURL = $"https://localhost:7143/api/SanPham/create_sp";
            var respones = _httpClient.PostAsJsonAsync(requestURL,request).Result;
            if (respones.IsSuccessStatusCode)
            {
                return true;
            }return false;
        }

        public bool DeleteSP(Guid id)
        {
            string requestURL = $"https://localhost:7143/api/SanPham/delete_sp?id={id}";
            var respones = _httpClient.DeleteAsync(requestURL).Result;
            if (respones.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

       
        public bool UpdateSP(Guid id, SanPhamRequest request)
        {
            string requestURL = $"https://localhost:7143/api/SanPham/update_sp?id={id}";
            var respones = _httpClient.PutAsJsonAsync(requestURL, request).Result;
            if (respones.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
