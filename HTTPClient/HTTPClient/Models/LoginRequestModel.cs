using Newtonsoft.Json;

namespace HTTPClient.Models
{
    public class LoginRequestModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
