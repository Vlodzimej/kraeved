using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Net.Http.Headers;

namespace KraevedAPI.Service
{
    public partial class KraevedService : IKraevedService
    {
        public async Task<String> SendSms(string message)
        {
            var phone = "79105968117";
            var apiKey = "MJ6BR436N7IW5VX97R1JIM36CO8N548L0ZOJ755X6127X0E3EJ9789YU50CMAYU";
            //var url = $"https://smspilot.ru/api.php?send=hello&to={phone}&apikey={apiKey}";

            var url = $"https://smspilot.ru/api.php?balance=rur&apikey={apiKey}";

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Headers = {
                    { HeaderNames.Accept, "application/json" },
                    { HeaderNames.UserAgent, "KraevedAPI/0.1" },
                    { HeaderNames.AcceptCharset, "utf-8" }
                }
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponse = await httpClient.SendAsync(httpRequestMessage);

            
            if (httpResponse.IsSuccessStatusCode)
            {
                var contentString = await httpResponse.Content.ReadAsStringAsync();
                return contentString;
            } 
            return "";
        }
    }
}