Feature: SearchPage
	As a Bing User
	I navigate to Bing searches
	And see my search listed

Scenario: SuccessfulSearchTest
	* Navigate to Bing home page.
	* Enter 'Hello World' in the searchbox.
	* See the displayed results according to your search.

Scenario: CheckPageElementsTest
	* Navigate to Bing home page.
	* Enter 'Hello World' in the searchbox.
	* The page elements are displayed correctly.

Scenario: ClearSearchBoxUsingClearSearchButtonTest
	* Navigate to Bing home page.
	* Enter 'Hello World' in the searchbox.
	* Click on clear search button.
	* Verify that search box is empty.

Scenario: SearchWithNoResultsTest
	* Navigate to Bing home page.
	* Enter 'pqhxaxada' in the searchbox.
	* See no results for your search.

Scenario: SearchWithTypoTest
	* Navigate to Bing home page.
	* Enter 'ello World' in the searchbox.
	* Verify that the typo recognition prompt is being displayed.

