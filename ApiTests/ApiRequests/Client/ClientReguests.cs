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


        public static string SendReguestChangeClientFirstNamePatch(string firstName, string lastName, string token)
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

        public static string SendReguestChangeClientLastNamePatch(string lastName, string token)
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

        public static string SendReguestChangeClientCompanyLocationPatch(string locationName, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            var newLocationModel = new Dictionary<string, string>
            {
                {"location_name", locationName }
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newLocationModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var ChangeProfileResponse = JsonConvert.DeserializeObject<ChangeProfileResponse>(response.Content);

            return ChangeProfileResponse.LocationName;
        }

        public static string SendReguestChangeClientIndustryPatch(string industry, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            var newLocationModel = new Dictionary<string, string>
            {
                {"industry", industry }
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newLocationModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var ChangeProfileResponse = JsonConvert.DeserializeObject<ChangeProfileResponse>(response.Content);

            return ChangeProfileResponse.Industry;
        }
        
        public static string SendReguestUploadClientImagesPatch(string token, string avatarId)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            client.Timeout = -1;
            var request = new RestRequest(Method.PATCH);

            request.AddHeader("authorization", token);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("avatar_id", avatarId);         

            var response = client.Execute(request);
            var AvatarResponse = JsonConvert.DeserializeObject<AvatarResponse>(response.Content.);

            return AvatarResponse.Id;
        }
    }
}
