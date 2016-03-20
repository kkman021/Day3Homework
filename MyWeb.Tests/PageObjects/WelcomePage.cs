using System;
using System.Configuration;
using FluentAutomation;

namespace MyWeb.Tests.PageObjects
{
    public class WelcomePage : PageObject<WelcomePage>
    {
        public WelcomePage(FluentTest test) : base(test)
        {
            //定義測試網址Url
            Url = $"{ConfigurationManager.AppSettings["TestTargetUrl"]}/{"Welcome"}";
        }

        internal void CheckPage()
        {
            throw new NotImplementedException();
        }

        internal void CheckMessage(string expectMsg)
        {
            throw new NotImplementedException();
        }
    }
}