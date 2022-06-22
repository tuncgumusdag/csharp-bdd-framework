using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;

namespace CSharpFramework.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        private ILog logger;

        public void LogPageLoad(object pageLoadTime)
        {
            logger.Info(TestContext.CurrentContext.Test.Name);
            logger.Info(pageLoadTime.ToString());
        }

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized", "test-type", "--disable-infobars", "--disable-notifications", "enable-automation");
            driver = new ChromeDriver(options);

            logger = LogManager.GetLogger(GetType());
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
