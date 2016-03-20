using System;
using System.Configuration;
using FluentAutomation;

namespace MyWeb.Tests.PageObjects
{
    //Page Object必須繼承Page Object
    public class LoginPage : PageObject<LoginPage>
    {
        public LoginPage(FluentTest test) : base(test)
        {
            //定義測試網址Url
            Url = $"{ConfigurationManager.AppSettings["TestTargetUrl"]}/{"Login"}";
        }

        public void EnterAccount(string accountName)
        {
            throw new System.NotImplementedException();
        }

        internal void EnterPwd(string password)
        {
            throw new NotImplementedException();
        }

        internal void ClickLogin()
        {
            throw new NotImplementedException();
        }
    }
}