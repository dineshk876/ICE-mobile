using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace BDD_AutomationTests.Pages
{
    public class LoginPage
    {

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By usernameTextbox = By.XPath("//input[@id='username']");
        By passwordTextbox = By.XPath("//input[@id='password']");
        By invalidMessage = By.XPath("//span[@class='ng-binding']");



        public void ExecuteLogin(string userName, string password)
        {
            driver.Url = BDD_AutomationTests.Hooks.Hooks.config.ApplicationURL;         
            driver.FindElement(usernameTextbox).SendKeys(userName);
            driver.FindElement(passwordTextbox).SendKeys(password);
            driver.FindElement(passwordTextbox).SendKeys(Keys.Enter);
        }
        public void InvalidAccountMessage()
        {
            IWebElement _invalidassert = driver.FindElement(invalidMessage);
            string _er = _invalidassert.Text;
            Assert.That(_er, Is.EqualTo(_er), "error");
        }
    }
}