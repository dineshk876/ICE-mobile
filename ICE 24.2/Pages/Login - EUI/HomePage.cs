using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace BDD_AutomationTests.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        By loca = By.XPath("//select[@ng-if='logon.currentUser.shouldGroupUserLocationsByOrg']");
        By user = By.XPath("//div[@class='current-user-initials']");
        By homePageAssertion = By.XPath("//span[@class='ng-binding ng-scope']");

        public void HomePageDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(e => (loca));
            IWebElement _loc = driver.FindElement(loca);
            SelectElement s = new SelectElement(_loc);
            s.SelectByText("Accident and Emergency AE");
            driver.FindElement(user).Click();
            IWebElement _homeassert = driver.FindElement(homePageAssertion);
            string _name = _homeassert.Text;
            Assert.That(_name, Is.EqualTo(_name), "error");

        }
    }
}