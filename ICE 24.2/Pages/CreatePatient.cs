using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_AutomationTests.Pages
{
    
    public class CreatePatient
    {
        public IWebDriver driver;

        public CreatePatient(IWebDriver driver)
        {
            this.driver = driver;
        }

        By _loca = By.XPath("//select[@ng-if='logon.currentUser.shouldGroupUserLocationsByOrg']");
        By _patient = By.XPath("//body/div[@class='application data-ng-cloak']/header[@class='navigation ng-scope']/nav[@class='ng-scope']/ul[@class='primary hide']/ice-menu-item[3]/li[1]");
        By _my = By.XPath("//li[@class='parent ng-scope haschild open']//li[1]");
        By _addicon = By.XPath("//i[@class='fa fa-fw fa-user-plus icon']");
        By _forename = By.XPath("//label[@data-label='Demographic.Forename']");
        By _surname = By.XPath("//label[@data-label='Demographic.Surname']");
        By _dob = By.XPath("(//input[@class='form-input date ng-pristine ng-untouched ng-scope ng-empty ng-valid-min ng-valid-max ng-invalid ng-invalid-required'])[1]");
        By _gender = By.XPath("//select[@class='form-input ng-pristine ng-untouched ng-empty ng-invalid ng-invalid-required']");
        By _address1 = By.XPath("//ng-switch[@class='form-value ng-scope']//input[@placeholder='Address line 1']");
        By _postcode = By.XPath("//input[@placeholder='Post Code']");
        By _submit = By.XPath("//i[@class='fa fa-fw fa-floppy-o icon']");
        By _new = By.XPath("//i[@class='fa fa-fw fa-plus-square-o icon']");

        public void loca()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(e => (_loca));
            IWebElement _loc = driver.FindElement(_loca);
            SelectElement s = new SelectElement(_loc);
            s.SelectByText("Accident and Emergency AE");
            
        }
            public void patient()
        {
            driver.FindElement(_patient).Click();
        }
        public void mypatient()
        {
            driver.FindElement(_my).Click();
        }
        public void addicon()
        {
            driver.FindElement(_addicon).Click();
        }
        public void forename()
        {
            driver.FindElement(_forename).SendKeys("wqdw");
        }
        public void surname()
        {
            driver.FindElement(_surname).SendKeys("wqdw");
        }
        public void dob()
        {
            driver.FindElement(_dob).SendKeys("11/11/1998");
        }
        public void gender()
        {
            IWebElement _Gender = driver.FindElement(_gender);
            SelectElement d = new SelectElement(_Gender);
            d.SelectByText("Male");
        }
        public void address1()
        {
            driver.FindElement(_address1).SendKeys("etynrn");
        }
        public void postcode()
        {
            driver.FindElement(_postcode).SendKeys("GHJ57HG");
        }
        public void submit()
        {
            driver.FindElement(_submit).Click();
        }
        public void New()
        {
            driver.FindElement(_new).Click();
        }
}
}
