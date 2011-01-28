Feature: Can handle a class with multiple dependencies
	In order to be able to use complex testable objects
	As a developer
	I want to be able to be able to supply different types of dependencies

@Testable
Scenario: Support multiple different ways of obtaining dependencies
	Given I specify a default dependency to use
	And I have a testable object
    And I use a dependency ExplicitDependency
	When I use the testable object
    Then I should have a default dependency with the correct type
    And I should have an explicit dependency
	And I should have a canned dependency
    And I should have a mocked dependency