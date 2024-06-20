using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System;


namespace BDD_AutomationTests.Behavior
{
    public class Baseclass
    {
        public static IWebDriver driver = null!;
        public static Actions actions = null!;
        public static IAlert alert = null!;
        public static IJavaScriptExecutor jsExecutor = null!;
        public static SelectElement selectElement = null!;

        public static void Launch()
        {
            driver = new ChromeDriver();
        }

        public static void Maximize()
        {
            driver.Manage().Window.Maximize();
        }

        public static string GetText(IWebElement element)
        {
            return element.Text;
        }

        public static string GetAttribute(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static void Url(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void ToFill(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public static void ButtonClick(IWebElement element)
        {
            element.Click();
        }

        public static void Actions(IWebElement target)
        {
            actions = new Actions(driver);
            actions.MoveToElement(target).Perform();
        }

        public static void DragAndDrop(IWebElement src, IWebElement dest)
        {
            actions = new Actions(driver);
            actions.DragAndDrop(src, dest).Perform();
        }

        public static void DoubleClick(IWebElement target)
        {
            actions = new Actions(driver);
            actions.DoubleClick(target).Perform();
        }

        public static void ContextClick(IWebElement element)
        {
            actions = new Actions(driver);
            actions.ContextClick(element).Perform();
        }

        public static void KeyEnter()
        {
            actions = new Actions(driver);
            actions.SendKeys(Keys.Enter).Perform();
        }

        public static void KeyUp()
        {
            actions = new Actions(driver);
            actions.SendKeys(Keys.Up).Perform();
        }

        public static void KeyDown()
        {
            actions = new Actions(driver);
            actions.SendKeys(Keys.Down).Perform();
        }

        public static void AlertAccept()
        {
            alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        public static void AlertDismiss()
        {
            alert = driver.SwitchTo().Alert();
            alert.Dismiss();
        }

        public static void AlertSendKeys(string text)
        {
            alert = driver.SwitchTo().Alert();
            alert.SendKeys(text);
        }

        public static void AlertText()
        {
            alert = driver.SwitchTo().Alert();
            Console.WriteLine(alert.Text);
        }

        public static void ScrollDown(IWebElement element)
        {
            jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void ScrollUp(IWebElement element)
        {
            jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(false);", element);
        }

        public static void Frames(string frameName)
        {
            driver.SwitchTo().Frame(frameName);
        }

        public static void WindowHandling(int index)
        {
            var windows = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(windows[index]);
        }

        public static void Dropdown(IWebElement element, string text)
        {
            selectElement = new SelectElement(element);
            selectElement.SelectByText(text);
        }

        public static void Waits()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }
    }
}
