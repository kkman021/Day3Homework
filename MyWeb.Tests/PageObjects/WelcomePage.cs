using System;
using System.Configuration;
using FluentAutomation;

namespace MyWeb.Tests.PageObjects
{
    public class WelcomePage : PageObject<WelcomePage>
    {
        private const string welcomeMessageContainer = "#message";

        public WelcomePage(FluentTest test) : base(test)
        {
            //定義測試網址Url
            Url = $"{ConfigurationManager.AppSettings["TestTargetUrl"]}/{"Welcome"}";
        }

        internal void CheckPage()
        {
            //我預期網址要等於定義的網址
            I.Assert.Url(this.Url);
        }

        internal void CheckMessage(string expectMsg)
        {
            //我預期的文字要在指定的Container中
            I.Assert.Text(expectMsg).In(welcomeMessageContainer);
        }
    }
}