using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace ApiTests
{
    public class NewBookModelsTests
    {
        [Test]
        public void CheckSuccessfulChangeEmail()
        {
            var expectedEmail = $"testemail{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com";
            var user = new Dictionary<string, string>
            {
                { "email", $"testemail{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Vitalik" },
                { "last_name", "Petrenko" },
                { "password", "QWE147asd-" },
                { "phone_number", "3456744567" }
            };

            var crearedUser = AuthReguests.SendRequestClientSingUpPost(user);

            var changedEmail = ClientReguests.SendReguestChangeClientEmailPost("QWE147asd-", expectedEmail, crearedUser.TokenData.Token);

            Assert.AreEqual(expectedEmail, changedEmail);
        }   

        [Test]
        public void CheckSuccessfulChangePassword()
        {
            var expectedPassword = $"{DateTime.Now:ddyyyymmHHssmmffff}QWEasd-";

            var user = new Dictionary<string, string>
            {
                { "email", $"testemail{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Vitalik" },
                { "last_name", "Petrenko" },
                { "password", "QWE147asd-" },
                { "phone_number", "3456744567" }
            };

            var crearedUser = AuthReguests.SendRequestClientSingUpPost(user);            

            var changedPassword = ClientReguests.SendReguestChangeClientPasswordPost("QWE147asd-", expectedPassword, crearedUser.TokenData.Token);

            Assert.AreEqual(crearedUser.TokenData.Token, changedPassword);
        }

        [Test]
        public void CheckSuccessfulChangePhoneNumber()
        {
            var expectedPhoneNumber = $"{DateTime.Now:ddyyyymmHH}";

            var user = new Dictionary<string, string>
            {
                { "email", $"testemail{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Vitalik" },
                { "last_name", "Petrenko" },
                { "password", "QWE147asd-" },
                { "phone_number", "3456744567" }
            };

            var crearedUser = AuthReguests.SendRequestClientSingUpPost(user);            

            var changedPhoneNumber = ClientReguests.SendReguestChangeClientPhoneNumberPost("QWE147asd-", expectedPhoneNumber, crearedUser.TokenData.Token);

            Assert.AreEqual(expectedPhoneNumber, changedPhoneNumber);
        } 

        [Test]
        public void CheckSuccessfulChangeFirstName()
        {
            var expectedFirstName = $"{DateTime.Now:ddyyyymmHH}";

            var user = new Dictionary<string, string>
            {
                { "email", $"testemail{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Vitalik" },
                { "last_name", "Petrenko" },
                { "password", "QWE147asd-" },
                { "phone_number", "3456744567" }
            };

            var crearedUser = AuthReguests.SendRequestClientSingUpPost(user);            

            var changedFirstName = ClientReguests.SendReguestChangeClientFirstNamePatch(expectedFirstName, crearedUser.User.LastName, crearedUser.TokenData.Token);

            Assert.AreEqual(expectedFirstName, changedFirstName);
        }

        [Test]
        public void CheckSuccessfulChangeLastName()
        {
            var expectedLastName = $"{DateTime.Now:ddyyyymmHH}";

            var user = new Dictionary<string, string>
            {
                { "email", $"testemail{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Vitalik" },
                { "last_name", "Petrenko" },
                { "password", "QWE147asd-" },
                { "phone_number", "3456744567" }
            };

            var crearedUser = AuthReguests.SendRequestClientSingUpPost(user);            

            var changedLastName = ClientReguests.SendReguestChangeClientLastNamePatch(expectedLastName, crearedUser.TokenData.Token);

            Assert.AreEqual(expectedLastName, changedLastName);
        }

         [Test]
        public void CheckSuccessfulChangeClientProfileLocation()
        {
            var expectedLocation = "45415 Dulles Crossing Plaza, Sterling, VA 20166, —ÿ¿";

            var user = new Dictionary<string, string>
            {
                { "email", $"testemail{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Vitalik" },
                { "last_name", "Petrenko" },
                { "password", "QWE147asd-" },
                { "phone_number", "3456744567" }
            };

            var crearedUser = AuthReguests.SendRequestClientSingUpPost(user);            

            var changedLocation = ClientReguests.SendReguestChangeClientCompanyLocationPatch(expectedLocation, crearedUser.TokenData.Token);

            Assert.AreEqual(expectedLocation, changedLocation);
        }

         [Test]
        public void CheckSuccessfulChangeClientProfileIndustry()
        {
            var expectedIndustry = $"{DateTime.Now:ddyyyymmHH}";

            var user = new Dictionary<string, string>
            {
                { "email", $"testemail{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Vitalik" },
                { "last_name", "Petrenko" },
                { "password", "QWE147asd-" },
                { "phone_number", "3456744567" }
            };

            var crearedUser = AuthReguests.SendRequestClientSingUpPost(user);            

            var changedIndustry = ClientReguests.SendReguestChangeClientIndustryPatch(expectedIndustry, crearedUser.TokenData.Token);

            Assert.AreEqual(expectedIndustry, changedIndustry);
        }

        [Test]
        public void CheckSuccessfulUploadClientImages()
        {
            var expectedImage = "334b960e-4d92-4bc5-a059-4540ca2fa8af";
            var user = new Dictionary<string, string>
            {
                { "email", $"testemail{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Vitalik" },
                { "last_name", "Petrenko" },
                { "password", "QWE147asd-" },
                { "phone_number", "3456744567" }
            };

            var crearedUser = AuthReguests.SendRequestClientSingUpPost(user); 
            
            var changedImage = ClientReguests.SendReguestUploadClientImagesPatch(crearedUser.TokenData.Token, expectedImage);

            Assert.AreEqual(expectedImage, changedImage);
        }

    }
}
