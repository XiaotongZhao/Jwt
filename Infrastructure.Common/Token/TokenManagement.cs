using Newtonsoft.Json;

namespace Infrastructure.Common.Token
{
    [JsonObject("TokenManagement")]
    public class TokenManagement
    {
        [JsonProperty("Secret")]
        public string Secret { get; set; }

        [JsonProperty("Issuer")]
        public string Issuer { get; set; }

        [JsonProperty("Audience")]
        public string Audience { get; set; }

        [JsonProperty("AccessExpiration")]
        public int AccessExpiration { get; set; }

        [JsonProperty("AefreshExpiration")]
        public int RefreshExpiration { get; set; }
    }
}
