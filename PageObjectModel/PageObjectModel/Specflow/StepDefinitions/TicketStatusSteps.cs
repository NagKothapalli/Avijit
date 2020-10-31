using PageObjectModel.GeneralUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace PageObjectModel.Specflow.StepDefinitions
{
    [Binding]
    public class TicketStatusSteps : ReportGenarator
    {
        private readonly ScenarioContext _scenarioContext;
        public TicketStatusSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            Console.WriteLine("Scenario Name :" + _scenarioContext.ScenarioInfo.Title);
        }
        [When(@"I Navigate to Ticket Status")]
        public void WhenINavigateToTicketStatus()
        {
            // ScenarioContext.Current.Pending();
            LogReport(true, Runner.Child, "WhenINavigateToTicketStatus");
        }

        [When(@"I gave the ticket number and search")]
        public void WhenIGaveTheTicketNumberAndSearch()
        {
            // ScenarioContext.Current.Pending();
            LogReport(true, Runner.Child, "WhenIGaveTheTicketNumberAndSearch");
        }

        [Then(@"I could see the ticket status")]
        public void ThenICouldSeeTheTicketStatus()
        {
            // ScenarioContext.Current.Pending();
            LogReport(true, Runner.Child, "ThenICouldSeeTheTicketStatus");
        }

    }
}
