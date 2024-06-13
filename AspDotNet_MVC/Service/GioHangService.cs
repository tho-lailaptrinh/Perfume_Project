using AspDotNet_MVC.IService;
using Infrastructure.EntityRequest;
using Newtonsoft.Json;

namespace AspDotNet_MVC.Service
{
    public class GioHangService : IGioHangService
    {
        HttpClient _httpClient;
        public GioHangService()
        {
            _httpClient = new HttpClient();
        }
        public List<GioHangRequest> GetAllGioHang()
        {
            string requestURL = "https://localhost:7143/api/GioHang/get_giohang";
            var respones = _httpClient.GetStringAsync(requestURL).Result;
            var data = JsonConvert.DeserializeObject<List<GioHangRequest>>(respones);
            return data;
        }
    }
}
