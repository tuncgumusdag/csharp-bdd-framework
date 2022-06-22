using NUnit.Framework;
using OpenQA.Selenium;
using CSharpFramework.Base;

namespace CSharpFramework.PageModels
{
    class HomePageModel : BasePage
    {
        protected By txtSearchBox = By.Id("sb_form_q");
        protected By icoLogo = By.Id("bLogo");
        protected By lblImages = By.Id("images");
        protected By lblVideos = By.Id("video");
        protected By lblTranslate = By.Id("translate");
        protected By lblMoreOptions = By.Id("dots_overflow_menu_container");
        protected By lblLanguage = By.ClassName("sw_lang");
        protected By lblSignIn = By.Id("id_s");
        protected By btnAccount = By.Id("id_a");
        protected By btnSettings = By.Id("id_sc");
        protected By btnMicrophone = By.XPath("//div[@class='mic_cont icon']");
        protected By btnSearchByImage = By.XPath("//div[@class='camera icon ']");
        protected By btnSearch = By.Id("search_icon");

        public HomePageModel(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void searchText(string textToSearch)
        {
            WaitElementStaleness(txtSearchBox);
            ClickElement(txtSearchBox);
            SendKeys(txtSearchBox, textToSearch);
            SendKeys(txtSearchBox, Keys.Enter);
        }

        public void checkPageElements()
        {
            string textToCheck = "Hello World!";
            WaitElementStaleness(txtSearchBox);
            Assert.True(IsElementVisible(txtSearchBox), "Search box was not found.");
            Assert.True(IsElementVisible(icoLogo), "Logo was not found.");
            Assert.True(IsElementVisible(lblImages), "Images tab was not found.");
            Assert.True(IsElementVisible(lblVideos), "Videos tab was not found.");
            Assert.True(IsElementVisible(lblTranslate), "Translate tab was not found.");
            Assert.True(IsElementVisible(lblMoreOptions), "More options tab was not found.");
            Assert.True(IsElementVisible(lblLanguage), "Change language tab was not found.");
            Assert.True(IsElementVisible(lblSignIn), "Sign In tab was not found.");
            Assert.True(IsElementVisible(btnAccount), "Account tab was not found.");
            Assert.True(IsElementVisible(btnSettings), "Settings tab was not found.");
            Assert.True(IsElementVisible(btnMicrophone), "Microphone button found.");
            Assert.True(IsElementVisible(btnSearchByImage), "Search by image button was not found.");
            Assert.True(IsElementVisible(btnSearch), "Search button was not found.");

            SendKeys(txtSearchBox, textToCheck);
            Assert.AreEqual(GetElementAttribute(txtSearchBox, "value"), textToCheck);
        }

    }
}
