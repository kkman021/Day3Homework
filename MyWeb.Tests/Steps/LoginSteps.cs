using System;
using System.Drawing.Text;
using FluentAutomation;
using MyWeb.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace MyWeb.Tests.Steps
{
    [Binding]
    //因為Step預設是全專案共用，可能有打架的狀況，所以，透過Scope將此Class中的Function框住
    [Scope(Feature = "Login")]
    public class LoginSteps : FluentTest    //我們期望我們是透過PageObject來將使用者與畫面切割，所以必須繼承FluentTest
    {
        //目標頁面有兩個，登入頁＆歡迎頁面，所以，先宣告兩個Page Object
        private LoginPage _loginPage;
        private WelcomePage _welcomePage;

        [Given(@"我前往登入頁面")]
        public void Given我前往登入頁面()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"帳號輸入 ""(.*)""")]
        public void Given帳號輸入(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"密碼輸入 ""(.*)""")]
        public void Given密碼輸入(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"當我按下登入")]
        public void When當我按下登入()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"應該導回歡迎頁面")]
        public void Then應該導回歡迎頁面()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"畫面應該呈現 ""(.*)""")]
        public void Then畫面應該呈現(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
