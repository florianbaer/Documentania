Feature: DocumentSave
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have a RavenDB Repository
	When I add a Document to the Repository
	Then I get 1 Document when i get all Documents
