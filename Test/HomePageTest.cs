using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using CSharpFramework.Base;
using CSharpFramework.PageModels;

namespace CSharpFramework.Test
{
    [Binding, Scope(Feature = "HomePage")]
    class HomePageTest : BaseTest
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
            homePage.checkPageElements();
        }
    }
}
