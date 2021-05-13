using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace ApiTests
{
    public static class ClientReguests
    {
        public static string SendReguestChangeClientEmailPost(string password, string email, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_email/");
            var request = new RestRequest(Method.POST);
            var newEmailModel = new Dictionary<string, string>
            {
                { "email", email },
                { "password", password },
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newEmailModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var ChangeEmailResponse = JsonConvert.DeserializeObject<ChangeEmailResponse>(response.Content);

            return ChangeEmailResponse.Email;
        }

        public static string SendReguestChangeClientPasswordPost(string password, string newPassword, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/password/change/");
            var request = new RestRequest(Method.POST);
            var newPasswordModel = new Dictionary<string, string>
            {
                { "old_password", password},
                { "new_password", newPassword},
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newPasswordModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var ChangePasswordResponse = JsonConvert.DeserializeObject<ChangePasswordResponse>(response.Content);

            return ChangePasswordResponse.Token;
        }

        public static string SendReguestChangeClientPhoneNumberPost(string password, string phoneNumber, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_phone/");
            var request = new RestRequest(Method.POST);
            var newPhoneNumberModel = new Dictionary<string, string>
            {
                { "password", password },
                { "phone_number", phoneNumber},
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newPhoneNumberModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var ChangePhoneNumberResponse = JsonConvert.DeserializeObject<ChangePhoneNumberResponse>(response.Content);

            return ChangePhoneNumberResponse.PhoneNumber;
        }


        public static string SendReguestChangeClientFirstNamePost(string firstName, string lastName, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.PATCH);
            var newFirstNameModel = new Dictionary<string, string>
            {
                { "first_name", firstName },
                 { "last_name", lastName},
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newFirstNameModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var ChangeSelfResponse = JsonConvert.DeserializeObject<ChangeSelfResponse>(response.Content);

            return ChangeSelfResponse.FirstName;
        }

        public static string SendReguestChangeClientLastNamePost(string lastName, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.PATCH);
            var newSelfModel = new Dictionary<string, string>
            {
                { "last_name", lastName},
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newSelfModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var ChangeSelfResponse = JsonConvert.DeserializeObject<ChangeSelfResponse>(response.Content);

            return ChangeSelfResponse.LastName;
        }
    }
}
