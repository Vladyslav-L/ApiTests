using Newtonsoft.Json;

namespace ApiTests
{
    public class UserSignUpModel
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
