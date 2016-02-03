Feature: DocumentSave
	In order to verify the saving of scanned documents
	As a chaotic developer
	I want to be sure that the repository works

@mytag
Scenario: Add and get a Document
	Given I have a RavenDB Repository
	When I add a Document to the Repository
	Then I get 1 Document when i get all Documents
