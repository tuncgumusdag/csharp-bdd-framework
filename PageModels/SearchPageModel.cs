using NUnit.Framework;
using OpenQA.Selenium;
using CSharpFramework.Base;

namespace CSharpFramework.PageModels
{
    class SearchPageModel : BasePage
    {
        protected By txtSearchBox = By.Id("sb_form_q");
        protected By icoLogo = By.ClassName("b_logoArea");
        protected By lblAllWeb = By.Id("b-scopeListItem-web");
        protected By lblImages = By.Id("b-scopeListItem-images");
        protected By lblVideo = By.Id("b-scopeListItem-video");
        protected By lblLocal = By.Id("b-scopeListItem-local");
        protected By lblNews = By.Id("b-scopeListItem-news");
        protected By btnMicrophone = By.XPath("//div[@class='mic_cont icon partner']");
        protected By btnSearchByImage = By.Id("sbiarea");
        protected By btnSearch = By.Id("sb_search");
        protected By btnClearSearch = By.Id("sb_clt");
        protected By lblResultCount = By.ClassName("sb_count");
        protected By lblDate = By.ClassName("fs_label");
        protected By btnSignIn = By.Id("id_a");
        protected By btnSettings = By.Id("id_sc");
        protected By lblNoResults = By.ClassName("b_no");
        protected By lblSearchResultTitle = By.ClassName("b_title");
        protected By lblTypoRequery = By.Id("sp_requery");
        protected By lblTypoRecourse = By.Id("sp_recourse");

        public SearchPageModel(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void checkSearchBoxText(string textToAssert)
        {
            WaitUntilElementVisible(txtSearchBox);
            Assert.AreEqual(textToAssert, GetElementAttribute(txtSearchBox, "value"));
        }

        public void searchText(string textToSearch)
        {
            WaitElementStaleness(txtSearchBox);
            SendKeys(txtSearchBox, textToSearch);
            SendKeys(txtSearchBox, Keys.Enter);
        }

        public void checkSuccessfulSearchPageElements()
        {
            Assert.False(GetElementText(lblResultCount) == string.Empty);
            Assert.True(IsElementVisible(lblSearchResultTitle));
        }

        public void checkPageElements()
        {
            WaitElementStaleness(icoLogo);
            Assert.True(IsElementVisible(txtSearchBox), "Search box was not found.");
            Assert.True(IsElementVisible(icoLogo), "Logo was not found.");
            Assert.True(IsElementVisible(lblAllWeb), "Web tab was not found.");
            Assert.True(IsElementVisible(lblImages), "Image tab was not found.");
            Assert.True(IsElementVisible(lblVideo), "Video tab was not found.");
            Assert.True(IsElementVisible(lblLocal), "Local tab was not found.");
            Assert.True(IsElementVisible(lblNews), "News tab was not found.");
            Assert.True(IsElementVisible(btnMicrophone), "Microphone button was not found.");
            Assert.True(IsElementVisible(btnSearchByImage), "Search by image button was not found.");
            Assert.True(IsElementVisible(btnSearch), "Search button was not found.");
            Assert.True(IsElementVisible(lblResultCount), "Results count was not found.");
            Assert.True(IsElementVisible(lblDate), "Date filter was not found.");
            Assert.True(IsElementVisible(btnSignIn), "Sign in button was not found.");
            Assert.True(IsElementVisible(btnSettings), "Settings button was not found.");
        }

        public void clickClearSearchBoxButton()
        {
            ClickElement(txtSearchBox);
            Assert.True(IsElementVisible(btnClearSearch), "Clear search button was not found.");
            ClickElement(btnClearSearch);
        }

        public void isSearchBoxEmpty(bool expected)
        {
            Assert.AreEqual(GetElementAttribute(txtSearchBox, "value") == string.Empty, expected);
        }

        public void checkNoResultSearchPageElements()
        {
            Assert.False(IsElementVisible(lblResultCount), "Search displayed a result count when it was expected not to.");
            Assert.True(IsElementVisible(lblNoResults), "No results text was not found.");
            Assert.False(IsElementVisible(lblSearchResultTitle), "Search found a result title when there should have been no search results.");
        }

        public void checkTypoRecognitionPrompt()
        {
            Assert.True(IsElementVisible(lblTypoRequery), "Typo requery prompt was not found.");
            Assert.True(GetElementText(lblTypoRequery).Contains("Including results for"));
            Assert.True(IsElementVisible(lblTypoRecourse), "Typo recourse prompt was not found.");
            Assert.True(GetElementText(lblTypoRecourse).Contains("Do you want results only for"));
        }

    }
}
