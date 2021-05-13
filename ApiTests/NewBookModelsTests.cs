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
    }
}
