using System.Net.Http;
using System.Threading.Tasks;

namespace WeShare.TransferJob.Sample
{
    public interface IBaiduApi
    {
        Task GetBaidu();
    }

    public class BaiduApi : IBaiduApi
    {
        private readonly IHttpClientFactory _clientFactory;

        public BaiduApi(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task GetBaidu()
        {
            var client = _clientFactory.CreateClient();
            await client.GetStringAsync("http://www.baidu.com");
        }
    }
}