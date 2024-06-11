using AspDotNet_MVC.IService;
using Infrastructure.EntityRequest;
using Newtonsoft.Json;

namespace AspDotNet_MVC.Service
{
    public class DanhMucSPService : IDanhMucSPService
    {
        HttpClient _client;
        public DanhMucSPService()
        {
            _client = new HttpClient();
        }
        public List<DanhMucSanPhamRequest> GetAll()
        {
            // đầu tiên cta cần phải có đường dẫn local hot
            string requestURL = "https://localhost:7143/api/DanhMucSP/getAll";
            // chúng ta sẽ sử dụng đối tượng client để gửi yêu cầu Get đến requestURL và đợi nhận lại kết quả .Result
            var respones = _client.GetStringAsync(requestURL).Result;
            // ở đây sử dụng thư viện Newtonsoft.Json phân tích chuỗi JSON trong response và chuyển đổi nó thành một List<DMSPR> và lưu vào biến data
            var data = JsonConvert.DeserializeObject<List<DanhMucSanPhamRequest>>(respones);
            return data;
        }
        public bool CreateDMSP(DanhMucSanPhamRequest dmsp)
        {
            string requestURL = "https://localhost:7143/api/DanhMucSP/getAll";
            var respones = _client.PostAsJsonAsync(requestURL, dmsp).Result;
            return true;
        }

        public bool DeleteDMSP(Guid id)
        {
            throw new NotImplementedException();
        }

       

        public DanhMucSanPhamRequest GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDMSP(DanhMucSanPhamRequest dmsp)
        {
            throw new NotImplementedException();
        }
    }
}
