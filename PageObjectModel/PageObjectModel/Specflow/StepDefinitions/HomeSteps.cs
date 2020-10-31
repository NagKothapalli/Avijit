using PageObjectModel.GeneralUtils;
using PageObjectModel.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace PageObjectModel.Specflow.StepDefinitions
{
    [Binding]
    public class HomeSteps : ReportGenarator
    {
        private readonly ScenarioContext _scenarioContext;
        public Home home;
        public Boolean result;
        public HomeSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            Console.WriteLine("Scenario Name :" + _scenarioContext.ScenarioInfo.Title);
            home = new Home(Runner.driver);
        }
        [When(@"I Book Ticket by giving journey details")]
        public void WhenIBookTicketByGivingJourneyDetails()
        {
            // ScenarioContext.Current.Pending();
            result = home.BookTicket();
            LogReport(true, Runner.Child, "BookTicketByGivingJourneyDetails");

        }

        [Then(@"I Could see the list of buses available")]
        public void ThenICouldSeeTheListOfBusesAvailable()
        {
            // ScenarioContext.Current.Pending();
            LogReport(true, Runner.Child, "ThenICouldSeeTheListOfBusesAvailable");
        }
        [When(@"I Book Ticket from ""(.*)"" to ""(.*)""")]
        public void WhenIBookTicketFromTo(string p0, string p1)
        {
            // ScenarioContext.Current.Pending();
            LogReport(true, Runner.Child, "WhenIBookTicketFromTo");
        }

        [When(@"I gave date of journey as ""(.*)"" and return journey as ""(.*)""")]
        public void WhenIGaveDateOfJourneyAsAndReturnJourneyAs(int p0, int p1)
        {
            // ScenarioContext.Current.Pending();
            LogReport(true, Runner.Child, "WhenIGaveDateOfJourneyAsAndReturnJourney");
        }

    }
}
