using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System;
using NUnit.Framework;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Chrome;
using Humanizer;

namespace DungeonsAndDragonsMonsterManualCSharp
{
    [Binding]
    public class MonsterSearchSteps
    {
        private  IWebDriver _driver;

        [BeforeScenario]
        public void SetUp()
        {
            _driver = new ChromeDriver();
        }
        [AfterScenario]
        public void TearDown()
        {
            _driver.Quit(); 
            _driver.Dispose();
        }

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            
            _driver.Navigate().GoToUrl("https://localhost:7068");

        }

        [When(@"I click the search bar")]
        public void WhenIClickTheSearchBar()
        {
            var searchBar = _driver.FindElement(By.Name("query"));
            searchBar.Click();
        }
        [When(@"I enter ""(.*)"" as the monster name")]
        public void WhenIEnterAsTheMonsterName(string monsterName)
        {
            var searchInput = _driver.FindElement(By.Name("query"));
            searchInput.Clear();
            searchInput.SendKeys(monsterName);
        }
        [When(@"I click the search button")]
        public void WhenIClickTheSearchButton()
        {
            var searchButton = _driver.FindElement(By.CssSelector("button[type='submit']"));
            searchButton.Click();
        }
        [Then(@"I should be redirected to the monster detail page for ""(.*)""")]
        public void ThenIShouldBeRedirectedToTheMonsterDetailPage(string monsterName)
        {
            // Locate the <dd> element displaying the monster's name
            var displayedMonsterName = _driver.FindElement(By.CssSelector("dd.col-sm-10")).Text;

            // Assert that the name matches the expected monster name
            Assert.That(displayedMonsterName.ToLower(), Does.Contain(monsterName.ToLower()),
                $"Expected monster name '{monsterName}' to be displayed, but found '{displayedMonsterName}'");
        }
    }
}
