Feature: HomePage
	As a Bing User
	I navigate to Bing home page
	And search for the thing I want

Scenario: SuccessfulSearchTest
	* Navigate to Bing home page.
	* Enter 'Hello World' in the searchbox.

Scenario: CheckPageElementsTest
	* Navigate to Bing home page.
	* The page elements are displayed correctly.
