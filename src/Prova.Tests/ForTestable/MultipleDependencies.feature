Feature: Can handle a class with multiple dependencies
	In order to be able to use complex testable objects
	As a developer
	I want to be able to be able to supply different types of dependencies

@Multiple_Dependencies
Scenario: Support multiple different ways of obtaining dependencies
	Given I specify that testable instances use a default dependency
	And I have a testable HasMultipleDependencies
    And I use an explicit dependency
	When I use the testable object
    Then I should have a default dependency
    And I should have an explicit dependency
	And I should have a canned dependency
    And I should have a mocked dependency