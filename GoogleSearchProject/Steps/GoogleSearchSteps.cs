using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace GoogleSearchProject.Steps
{
    [Binding]
    public class GoogleSearchSteps : Program
    {
        Program objPgm = new Program();

        [Given(@"I open browser")]
        public void GivenIOpenBrowser()
        {
            InitializeDriver();
        }

        [Given(@"I go to Google homepage")]
        public void GivenIGoToGoogleHomepage()
        {
            driver.Navigate().GoToUrl("http://google.com");
            driver.Manage().Window.Maximize();
        }

        
        [When(@"I hit the Enter button")]
        public void WhenIHitTheEnterButton()
        {
            //element.SearchKeyword(keyword);
            InitiateSearch();
        }

        [When(@"I enter (.*) to search")]
        public void WhenIEnterAivvaToSearch(string searchKey)
        {
            FindText(searchKey);
        }        

        [Then(@"I should see links in first search page")]
        public void ThenIShouldSeeLinksInFirstSearchPage()
        {
            int count = GetLinksCount();
            int numberOfLinks = 12;
            Console.WriteLine("Number of search links are : " + count);
            Assert.IsTrue(count == numberOfLinks);
            PrintLinkText(5);
        }

        [Then(@"I should not see previous links in first search page")]
        public void ThenIShouldNotSeePreviousLinksInFirstSearchPage()
        {
            int count = GetLinksCount();
            int numberOfLinks = 5;
            Console.WriteLine("Number of search links are : " + count);
            Assert.IsFalse(numberOfLinks == count);
            PrintLinkText(5);
        }
    }
}
