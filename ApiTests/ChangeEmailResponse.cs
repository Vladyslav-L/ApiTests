using Newtonsoft.Json;

namespace ApiTests
{
    public class ChangeEmailResponse
    {
        public string Email { get; set; }
    }

    public class ChangePhoneNumberResponse
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }

    public class ChangePasswordResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }


}
