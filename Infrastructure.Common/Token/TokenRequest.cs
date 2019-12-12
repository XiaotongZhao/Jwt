using Newtonsoft.Json;

namespace Infrastructure.Common.Token
{
    public class TokenRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }


        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
