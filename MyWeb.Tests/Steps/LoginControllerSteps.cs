using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentAssertions;
using FluentAssertions.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyWeb.Controllers;
using MyWeb.Models;
using TechTalk.SpecFlow;

namespace MyWeb.Tests.Steps
{
    [Binding]
    [Scope(Feature = "LoginController")]
    public class LoginControllerSteps
    {
        private LoginController _target;

        [BeforeScenario]
        public void BeforeScenario()
        {
            this._target = new LoginController();
        }

        [Given(@"帳號為 ""(.*)""")]
        public void Given帳號為(string accountName)
        {
            ScenarioContext.Current.Set<string>(accountName, nameof(accountName));
        }

        [Given(@"密碼為 ""(.*)""")]
        public void Given密碼為(string password)
        {
            ScenarioContext.Current.Set<string>(password, nameof(password));
        }

        [When(@"觸發登入HttpPost")]
        public void When觸發登入HttpPost()
        {
            var accountName = ScenarioContext.Current.Get<string>("accountName");
            var password = ScenarioContext.Current.Get<string>("password");

            var loginVm = new LoginVM() { Account = accountName, Pwd = password };

            //驗證ModelValidation
            var context = new ValidationContext(loginVm, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(loginVm, context, results, true);
            Assert.IsTrue(isModelStateValid);


            var actual = this._target.Index(loginVm);
            ScenarioContext.Current.Set<ActionResult>(actual);
        }

        [When(@"觸發登入HttpPost Model驗證失敗")]
        public void When觸發登入HttpPostModel驗證失敗()
        {
            var accountName = ScenarioContext.Current.Get<string>("accountName");
            var password = ScenarioContext.Current.Get<string>("password");

            var loginVm = new LoginVM() { Account = accountName, Pwd = password };

            //驗證ModelValidation
            var context = new ValidationContext(loginVm, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(loginVm, context, results, true);

            isModelStateValid.Should().BeFalse();

            var actual = this._target.Index(loginVm);
            ScenarioContext.Current.Set<ActionResult>(actual);
        }


        [Then(@"回覆的頁面Controller應該為 ""(.*)""")]
        public void Then回覆的頁面Controller應該為(string controllerName)
        {
            var actual = ScenarioContext.Current.Get<ActionResult>() as RedirectToRouteResult;

            Assert.IsNotNull(actual);
            Assert.AreEqual(controllerName, actual.RouteValues["Controller"]);

        }

        [Then(@"回覆的頁面Action應該為 ""(.*)""")]
        public void Then回覆的頁面Action應該為(string actionName)
        {
            var actual = ScenarioContext.Current.Get<ActionResult>() as RedirectToRouteResult;

            Assert.IsNotNull(actual);
            Assert.AreEqual(actionName, actual.RouteValues["Action"]);
        }

        [Then(@"ModelState應該沒通過")]
        public void ThenModelState應該沒通過()
        {
            var actual = ScenarioContext.Current.Get<ActionResult>();

            actual.Should().BeViewResult();
        }

    }
}
