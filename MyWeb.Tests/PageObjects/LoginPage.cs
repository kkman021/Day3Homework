using System;
using System.Configuration;
using FluentAutomation;

namespace MyWeb.Tests.PageObjects
{
    //Page Object必須繼承Page Object
    public class LoginPage : PageObject<LoginPage>
    {
        private const string AccountContainer = "#Account";
        private const string PasswordContainer = "#Pwd";
        private const string ErrormsgContainer = "#ErrorMsg";

        public LoginPage(FluentTest test) : base(test)
        {
            //定義測試網址Url
            Url = $"{ConfigurationManager.AppSettings["TestTargetUrl"]}/{"Login"}";
        }

        internal void EnterAccount(string accountName)
        {
            I.Enter(accountName).In(AccountContainer);
        }

        internal void EnterPwd(string password)
        {
            I.Enter(password).In(PasswordContainer);
        }

        internal void ClickLogin()
        {
            I.Append(OpenQA.Selenium.Keys.Enter).To(PasswordContainer);
        }

        internal void ShowErrorMsg(string expectMsg)
        {
            I.Assert.Text(expectMsg).In(ErrormsgContainer);
        }
    }
}