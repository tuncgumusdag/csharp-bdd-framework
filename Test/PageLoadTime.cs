using log4net.Layout;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using CSharpFramework.Base;
using CSharpFramework.PageModels;

namespace CSharpFramework.Test
{
    [Binding, Scope(Feature = "PageLoadTime")]
    class PageLoadTime : BaseTest
    {
        BasePage basePage;
        PageLoadTimeModel pageLoadTimeModel;

        [BeforeScenario]
        public void BeforeScenario()
        {
            SetUp();
            basePage = new BasePage(driver);
            pageLoadTimeModel = new PageLoadTimeModel(driver);
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

        [Given(@"Verify that loading time is shorter than '(.*)' seconds.")]
        public void VerifyLoadingTime(int loadTime)
        {
            double expectedLoadTime = TimeSpan.FromSeconds(loadTime).TotalMilliseconds;
            int pageLoadTimer = pageLoadTimeModel.GetPageLoadTime();
            LogPageLoad(pageLoadTimer);
            Assert.Less(pageLoadTimer, expectedLoadTime);
        }
    }
}
