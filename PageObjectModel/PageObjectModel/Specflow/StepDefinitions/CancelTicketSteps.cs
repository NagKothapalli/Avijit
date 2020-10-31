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
    public class CancelTicketSteps : ReportGenarator
    {
        private readonly ScenarioContext _scenarioContext;
        public CancelTicketSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            Console.WriteLine("Scenario Name :" + _scenarioContext.ScenarioInfo.Title);
        }
        [When(@"I Navigate to Cancel")]
        public void WhenINavigateToCancel()
        {
            // ScenarioContext.Current.Pending();
            LogReport(true, Runner.Child, "WhenINavigateToCancel");
        }

        [When(@"I Cancel the ticket")]
        public void WhenICancelTheTicket()
        {
            // ScenarioContext.Current.Pending();
            LogReport(true, Runner.Child, "WhenICancelTheTicket");
        }

        [Then(@"I could see the ticket got cancelled")]
        public void ThenICouldSeeTheTicketGotCancelled()
        {
            // ScenarioContext.Current.Pending();
            LogReport(true, Runner.Child, "ThenICouldSeeTheTicketGotCancelled");
        }

    }
}
