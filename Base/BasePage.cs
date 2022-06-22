using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace CSharpFramework.Base
{
    public class BasePage
    {
        public IWebDriver driver;
        protected WebDriverWait wait;
        public string TestUserGsm;
        public string TestUserPassword;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            TestUserGsm = ConfigurationManager.AppSettings["TESTUSER_GSM"];
            TestUserPassword = ConfigurationManager.AppSettings["TESTUSER_PASSWORD"];
        }

        /// <summary>
        /// Finds the first IWebElement using the given method after waiting for its visibility.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first matching IWebElement on the current context.</returns>
        /// <exception cref="T:OpenQA.Selenium.NoSuchElementException"></exception>
        public IWebElement FindElement(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            return driver.FindElement(by);
        }

        /// <summary>
        /// Finds all IWebElements within the current context using the given mechanism.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>A System.Collections.ObjectModel.ReadOnlyCollection`1 of all WebElements matching 
        /// the current criteria, or an empty list if nothing matches.</returns>
        /// <exception cref="T:OpenQA.Selenium.NoSuchElementException"></exception>
        public List<IWebElement> FindElements(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            return driver.FindElements(by).ToList();
        }

        /// <summary>
        /// Clicks the first IWebElement using the given method after waiting for its visibility.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        public void ClickElement(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            FindElement(by).Click();
        }

        /// <summary>
        /// Waits for the first IWebElement's visibility.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        public void WaitUntilElementVisible(By by)
        {
            for (int i = 0; i < 5; i++)
            {
                if (IsElementVisible(by))
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Waits for the first IWebElement to be clickable using the given method. 
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        public void WaitElementToBeClickable(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FindElement(by)));
        }

        /// <summary>
        /// Waits for the text to be present in the IWebElement. 
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        public void TextToBePresentInElement(By by, string text)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(FindElement(by), text));
        }

        /// <summary>
        /// Waits for the first IWebElement using the given method to lose its staleness. 
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        public void WaitElementStaleness(By by)
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(FindElement(by)));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        /// <summary>
        /// Hovers the mouse over the first IWebElement using the given method.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <exception cref="T:OpenQA.Selenium.NoSuchElementException"></exception>
        public void Hover(By by)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(FindElement(by)).Build().Perform();
        }

        /// <summary>
        /// Hovers the mouse over the first IWebElement using the given method.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="value">The text to be typed on the element.</param>
        /// <exception cref="T:OpenQA.Selenium.NoSuchElementException"></exception>
        /// <exception cref="T:OpenQA.Selenium.InvalidElementStateException"></exception>
        /// <exception cref="T:OpenQA.Selenium.ElementNotVisibleException"></exception>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException"></exception>
        public void SendKeys(By by, string value)
        {
            FindElement(by).SendKeys(value);
        }

        /// <summary>
        /// Gets a value indicating IWebElement's visibility using the given method.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>Returns a value whether or not this element is both enabled and displayed or not.</returns>
        public bool IsElementVisible(By by)
        {
            bool isVisible;

            try
            {
                isVisible = FindElement(by).Enabled && FindElement(by).Displayed;
            }
            catch
            {
                isVisible = false;
            }
            return isVisible;
        }

        /// <summary>
        /// Gets a value indicating IWebElement is checked using the given method.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>Returns a value whether or not this element is checked.</returns>
        /// <exception cref="T:OpenQA.Selenium.NoSuchElementException"></exception>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException"></exception>
        public bool IsElementChecked(By by)
        {
            return FindElement(by).Selected;
        }

        /// <summary>
        /// Gets the innerText of this IWebElement using the given method.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>Returns the innerText of this element, without any leading or trailing whitespace, and with other whitespace collapsed.</returns>
        /// <exception cref="T:OpenQA.Selenium.NoSuchElementException"></exception>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException"></exception>
        public string GetElementText(By by)
        {
            return FindElement(by).Text;
        }

        /// <summary>
        /// Gets the value of the specified attribute for this element.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The attribute's current value. Returns a null if the value is not set.</returns>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException"></exception>
        public string GetElementAttribute(By by, string attribute)
        {
            return FindElement(by).GetAttribute(attribute);
        }

        /// <summary>
        /// Loads Bing home page in the current browser window.
        /// </summary>
        public void OpenBingHomePage()
        {
            string domain = ConfigurationManager.AppSettings["DOMAIN"];
            NavigateTo(domain);
        }

        /// <summary>
        /// Load a new web page in the current browser window.
        /// </summary>
        /// <param name="url">The URL to load. It is best to use a fully qualified URL.</param>
        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Move back a single entry in the browser's history.
        /// </summary>
        public void NavigateToPreviousPage()
        {
            driver.Navigate().Back();
        }
    }
}
