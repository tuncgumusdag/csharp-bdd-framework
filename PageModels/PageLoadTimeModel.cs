using OpenQA.Selenium;
using System;
using CSharpFramework.Base;
namespace CSharpFramework.PageModels
{
    class PageLoadTimeModel : BasePage
    {
        public PageLoadTimeModel(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public int GetPageLoadTime()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var loadTime = js.ExecuteScript("return " +
                "window.performance.timing.domContentLoadedEventEnd-window.performance.timing.navigationStart");
            int pageLoadTime = Convert.ToInt32(loadTime);
            return pageLoadTime;
        }
    }
}
