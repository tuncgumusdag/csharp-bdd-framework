using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using CSharpFramework.Base;
using CSharpFramework.PageModels;

namespace CSharpFramework.Test
{
    [Binding, Scope(Feature = "SearchPage")]
    class SearchPageTest : BaseTest
    {
        BasePage basePage;
        HomePageModel homePage;
        SearchPageModel searchPage;

        [BeforeScenario]
        public void BeforeScenario()
        {
            SetUp();
            basePage = new BasePage(driver);
            homePage = new HomePageModel(driver);
            searchPage = new SearchPageModel(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            TearDown();
        }

        [Given(@"Navigate to Bing home page.")]
        public void NavigateToBing()
        {
            basePage.OpenBingHomePage();
        }

        [Given(@"Enter '(.*)' in the searchbox.")]
        public void EnterValueOnSearchBox(string textToSearch)
        {
            homePage.searchText(textToSearch);
            searchPage.checkSearchBoxText(textToSearch);
        }
        
        [Given(@"The page elements are displayed correctly.")]
        public void CheckPageElementsTest()
        {
            searchPage.checkPageElements();
        }

        [Given(@"See the displayed results according to your search.")]
        public void CheckDisplayedResults()
        {
            searchPage.checkSuccessfulSearchPageElements();
        }

        [Given(@"See no results for your search.")]
        public void CheckThatNoResultsAreBeingDisplayed()
        {
            searchPage.checkNoResultSearchPageElements();
        }

        [Given(@"Click on clear search button.")]
        public void ClickOnClearSearchButton()
        {
            searchPage.clickClearSearchBoxButton();
        }

        [Given(@"Verify that search box is empty.")]
        public void VerifyThatSearchBoxIsEmpty()
        {
            searchPage.isSearchBoxEmpty(true);
        }

        [Given(@"Verify that the typo recognition prompt is being displayed.")]
        public void VerifyTypeRecognitionPrompt()
        {
            searchPage.checkTypoRecognitionPrompt();
        }
    }
}
