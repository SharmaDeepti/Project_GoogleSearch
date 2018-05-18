@Search Functionality
Feature: GoogleSearch
As a user I want to search Aviva in Google
So that I can see number of links and link text

Scenario: Count of links displayed after searching Aviva in Google
	Given I open browser
	And I go to Google homepage
	When I enter "Aviva" to search
	And I hit the Enter button
	Then I should see links in first search page	
	
Scenario Outline: Count of links for searching other than Aviva in Google
	Given I open browser
	And I go to Google homepage
	When I enter <text> to search
	And I hit the Enter button
	Then I should not see previous links in first search page
	Examples:
	| text   |
	| Aivva1 |
	| abva   |