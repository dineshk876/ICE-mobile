using BDD_AutomationTests.Pages;

namespace BDD_AutomationTests.Behavior
{
    public class ExecuteLoginBehavior
    {
        private LoginPage loginPage;
        private string userName;
        private string password;
        public ExecuteLoginBehavior(LoginPage page, string userName, string password)
        {
            loginPage = page;
            this.userName = userName;
            this.password = password;
        }
        public void Perform()
        {
            loginPage.ExecuteLogin(userName, password);
        }
        private HomePage homePage;
        public ExecuteLoginBehavior(HomePage page)
        {
            homePage = page;
        }
        public void Perform1()
        {
            homePage.HomePageDisplayed();
        }
        public class InvalidLoginBehavior
        {
            private LoginPage loginPage;
            public InvalidLoginBehavior(LoginPage page)
            {
                loginPage = page;
            }
            public void Perform2()
            {
                loginPage.InvalidAccountMessage();
            }
        }
    }
}