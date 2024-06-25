using BDD_AutomationTests.Behavior;
using BDD_AutomationTests.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static BDD_AutomationTests.Behavior.ExecuteLoginBehavior;


namespace BDD_AutomationTests.Steps
{
    [Binding]
    public class CreatenewpatientStepDefinitions
    {
        IWebDriver driver;
        LoginPage _loginPage;
        CreatePatient createPatient;

        public CreatenewpatientStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            _loginPage = new LoginPage(driver);
           createPatient = new CreatePatient(driver);
        }

        [Given(@"user Login with ICE application")]
        public void GivenUserLoginWithICEApplication()
        {
            new singlelogin(_loginPage).login(); 
        }
        [When(@"Select location")]
        public void WhenSelectLocation()
        {
            //new ExecuteLoginBehavior(_homePage).Perform1();
            createPatient.loca();
        }


        [When(@"Navigate to patients")]
        public void WhenNavigateToPatients()
        {
            createPatient.patient();
        }

        [When(@"Click My Option")]
        public void WhenClickMyOption()
        {
            createPatient.mypatient();
        }

        [When(@"Click Add New Patient icon")]
        public void WhenClickAddNewPatientIcon()
        {
            createPatient.addicon();
        }

        [When(@"Enter Forename")]
        public void WhenEnterForename()
        {
            createPatient.forename();
        }

        [When(@"Enter Surname")]
        public void WhenEnterSurname()
        {
            createPatient.surname();
        }

        [When(@"Enter DOB")]
        public void WhenEnterDOB()
        {
            createPatient.dob();
        }

        [When(@"Select Gender")]
        public void WhenSelectGender()
        {
            createPatient.gender();
        }

        [When(@"Enter Address line")]
        public void WhenEnterAddressLine()
        {
            createPatient.address1();
        }

        [When(@"Enter Postcode")]
        public void WhenEnterPostcode()
        {
            createPatient.postcode();
        }

        [When(@"Click Save icon")]
        public void WhenClickSaveIcon()
        {
            createPatient.submit();
        }

        [Then(@"New patient demography is Created")]
        public void ThenNewPatientDemographyIsCreated()
        {
            createPatient.New();
        }
    }
}

