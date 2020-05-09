using Redcarpet.BDDtesting.PageObjects;
using TechTalk.SpecFlow;

namespace Redcarpet.BDDtesting.StepDefinitions
{
    [Binding]
    public sealed class LoginMemberSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public LoginMemberSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }
        #region When
        [When(@"User captures valid username and password and click login")]
        public void WhenUserCapturesValidUsernameAndPasswordAndClickLogin(Table table)
        {
            LoginPage lPage = new LoginPage();
            foreach (var row in table.Rows)
            {
                lPage.CaptureUserName(row["username"]);
                lPage.CapturePassword(row["password"]);
            }
        }

        [When(@"User captures valid ""(.*)"" and ""(.*)"" and click login")]
        public void WhenUserCapturesValidAndAndClickLogin(string username, string password, Table table)
        {
        }

        #endregion

        #region Then
        [Then(@"The user is taken to profile and the profile steps are displayed")]
        public void ThenTheUserIsTakenToProfileAndTheProfileStepsAreDisplayed()
        {
            MemberProfilePage mpPage = new MemberProfilePage();
            mpPage.profileIntro();
            mpPage.navigateToProfile();
        }

        #endregion

    }
}
