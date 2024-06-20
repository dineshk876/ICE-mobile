using BDD_AutomationTests.Behavior;
using BDD_AutomationTests.Drivers;
using BDD_AutomationTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using static BDD_AutomationTests.Behavior.ExecuteLoginBehavior;

namespace BDD_AutomationTests.StepDefinitions
{
    [Binding]
    public sealed class CommonStepDefinitions
    {
        private LoginPage loginPage;
        private HomePage homePage;
        private IWebDriver driver;

        public CommonStepDefinitions(IWebDriver driver)
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
        }

        [Given(@"Login with credentials (.*) and (.*)")]
        public void WhenLoginWithValidCredentials(string userName, string password)
        {
            new ExecuteLoginBehavior(loginPage, userName, password).Perform();
           
        }

        [Then(@"Verify home page is dispalyed")]
        public void ThenVerifyHomePageIsDispalyed()
        {
            new ExecuteLoginBehavior(homePage).Perform1();
        }

        [Then(@"Verify invalid credential message is displaying")]
        public void ThenVerifyInvalidCredentialMessageIsDisplaying()
        {
            new InvalidLoginBehavior(loginPage).Perform2();
        }

    }
}