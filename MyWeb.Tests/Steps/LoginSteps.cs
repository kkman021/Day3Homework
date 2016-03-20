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
        public LoginSteps()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }

        //BeforeSenario => 在每次情境開始前要做的事情
        [BeforeScenario]
        public void BeforeScenario()
        {
            this._loginPage = new LoginPage(this);
        }

        [Given(@"我前往登入頁面")]
        public void Given我前往登入頁面()
        {
            //.Go為FluentTest預設提供的方法，不需自己寫
            _loginPage.Go();
        }

        [Given(@"帳號輸入 ""(.*)""")]
        public void Given帳號輸入(string accountName)
        {
            //定義Page Object有一個輸入帳號的動作
            _loginPage.EnterAccount(accountName);
        }

        [Given(@"密碼輸入 ""(.*)""")]
        public void Given密碼輸入(string password)
        {
            //定義Page Object有一個輸入密碼的動作
            _loginPage.EnterPwd(password);
        }

        [When(@"當我按下登入")]
        public void When當我按下登入()
        {
            _loginPage.ClickLogin();
        }

        [Then(@"應該導回歡迎頁面")]
        public void Then應該導回歡迎頁面()
        {
            _welcomePage = new WelcomePage(this);
            _welcomePage.CheckPage();
        }

        [Then(@"畫面應該呈現 ""(.*)""")]
        public void Then畫面應該呈現(string expectMsg)
        {
            _welcomePage.CheckMessage(expectMsg);
        }

        [Then(@"錯誤訊息應該為 ""(.*)""")]
        public void Then錯誤訊息應該為(string expectMsg)
        {
            _loginPage.ShowErrorMsg(expectMsg);
        }

    }
}
