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
        private static ClientAuthModel _user;

        [SetUp]
        public void SetUp()
        {  
            var user = new Dictionary<string, string>
            {
                { "email", $"testemail{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com" },
                { "first_name", "Vitalik" },
                { "last_name", "Petrenko" },
                { "password", "QWE147asd-" },
                { "phone_number", "3456744567" }
            };

            _user = AuthReguests.SendRequestClientSingUpPost(user);
        }                

        [Test]
        public void CheckSuccessfulChangeEmail()
        {
            var expectedEmail = $"testemail{DateTime.Now:ddyyyymmHHssmmffff}@gmail.com";

            var changedEmail = ClientReguests.SendReguestChangeClientEmailPost("QWE147asd-", expectedEmail, _user.TokenData.Token);

            Assert.AreEqual(expectedEmail, changedEmail);
        }

        [Test]
        public void CheckSuccessfulChangePassword()
        {
            var expectedPassword = $"{DateTime.Now:ddyyyymmHHssmmffff}QWEasd-";

            var changedPassword = ClientReguests.SendReguestChangeClientPasswordPost("QWE147asd-", expectedPassword, _user.TokenData.Token);

            Assert.AreEqual(_user.TokenData.Token, changedPassword);
        }

        [Test]
        public void CheckSuccessfulChangePhoneNumber()
        {
            var expectedPhoneNumber = $"{DateTime.Now:ddyyyymmHH}";

            var changedPhoneNumber = ClientReguests.SendReguestChangeClientPhoneNumberPost("QWE147asd-", expectedPhoneNumber, _user.TokenData.Token);

            Assert.AreEqual(expectedPhoneNumber, changedPhoneNumber);
        }

        [Test]
        public void CheckSuccessfulChangeFirstName()
        {
            var expectedFirstName = $"{DateTime.Now:ddyyyymmHH}";

            var changedFirstName = ClientReguests.SendReguestChangeClientFirstNamePatch(expectedFirstName, _user.User.LastName, _user.TokenData.Token);

            Assert.AreEqual(expectedFirstName, changedFirstName);
        }

        [Test]
        public void CheckSuccessfulChangeLastName()
        {
            var expectedLastName = $"{DateTime.Now:ddyyyymmHH}";

            var changedLastName = ClientReguests.SendReguestChangeClientLastNamePatch(expectedLastName, _user.TokenData.Token);

            Assert.AreEqual(expectedLastName, changedLastName);
        }

        [Test]
        public void CheckSuccessfulChangeClientProfileLocation()
        {
            var expectedLocation = "45415 Dulles Crossing Plaza, Sterling, VA 20166, —ÿ¿";

            var changedLocation = ClientReguests.SendReguestChangeClientCompanyLocationPatch(expectedLocation, _user.TokenData.Token);

            Assert.AreEqual(expectedLocation, changedLocation);
        }

        [Test]
        public void CheckSuccessfulChangeClientProfileIndustry()
        {
            var expectedIndustry = $"{DateTime.Now:ddyyyymmHH}";

            var changedIndustry = ClientReguests.SendReguestChangeClientIndustryPatch(expectedIndustry, _user.TokenData.Token);

            Assert.AreEqual(expectedIndustry, changedIndustry);
        }

        [Test]
        public void CheckSuccessfulUploadClientImages()
        {
            var expectedImage = ClientReguests.SendReguestUploadClientImagesPost(_user.TokenData.Token);

            var changedImage = ClientReguests.SendReguestUploadClientImagesPatch(_user.TokenData.Token, expectedImage);

            Assert.AreEqual(expectedImage, changedImage);
        }
    }
}
