using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace PR_Comments_Extractor.Functionality
{
    public class AccessClient
    {
        private readonly HttpClient _httpClient;
        IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        string OrgName = "";
        public AccessClient()
        {
            //OrgName = ConfigurationManager.AppSettings[0];
            OrgName = config["Organization"];
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri($"https://dev.azure.com/{OrgName}/")
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<HttpResponseMessage> SendRequestAsync(string token, string relativeUrl)
        {
            try
            {
                var EncodedToken = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", token)));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", EncodedToken);
                HttpResponseMessage response = await _httpClient.GetAsync(relativeUrl);
                return response;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

        }
        public async Task<HttpResponseMessage> SendUserRequestAsync(string token, string relativeUrl)
        {
            try
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri($"https://{OrgName}.vsaex.visualstudio.com/")
                };
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var EncodedToken = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", token)));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", EncodedToken);
                HttpResponseMessage response = await httpClient.GetAsync(relativeUrl);
                return response;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

        }
        public async Task<HttpResponseMessage> SendUserInfoRequestAsync(string token, string relativeUrl)
        {
            try
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri($"https://vssps.dev.azure.com/{OrgName}/")
                };
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var EncodedToken = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", token)));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", EncodedToken);
                HttpResponseMessage response = await httpClient.GetAsync(relativeUrl);
                return response;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
        public async Task<HttpResponseMessage> SendPRRequestAsync(string token, string relativeUrl)
        {

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri($"https://dev.azure.com/{OrgName}/")
            };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var EncodedToken = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", token)));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", EncodedToken);
            HttpResponseMessage response = await httpClient.GetAsync(relativeUrl);
            return response;

        }
    }
}
