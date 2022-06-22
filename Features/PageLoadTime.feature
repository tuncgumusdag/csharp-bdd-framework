Feature: PageLoadTime
	As a Bing user 
	I navigate to Bing home page
	And wait for the pages to load in acceptable times

Scenario: WatchBingLoadTime
	* Navigate to Bing home page.
	* Verify that loading time is shorter than '5' seconds.