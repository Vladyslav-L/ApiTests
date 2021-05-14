using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace ApiTests
{
    public static class AuthReguests
    {
        public static ClientAuthModel SendRequestClientSingUpPost(Dictionary<string, string> user)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/client/signup/");
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var createdUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return createdUser;
        }

        // public static ClientAuthModel SendRequestClientSingUpPost(string email, string password)
        //{
        //    var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/signin/");
        //    var request = new RestRequest(Method.POST);
        //    var newSingInModel = new Dictionary<string, string>
        //    {
        //        { "email", email },
        //        { "password", password },
        //    };
        //    request.AddHeader("content-type", "application/json");            
        //    request.AddJsonBody(newSingInModel);

        //    request.RequestFormat = DataFormat.Json;

        //    var response = client.Execute(request);
        //    var StatusCodeResponse = JsonConvert.DeserializeObject<StatusCodeResponse>(response.Content);

        //    return StatusCodeResponse;
        //}

    }

}
