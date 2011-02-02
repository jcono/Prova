Feature: Can automatically provide different ways of obtaining dependencies for a type with multiple dependencies
    In order to be able to use complex testable objects
    As a developer
    I want different ways to be obtain dependencies

Scenario: Support multiple different ways of obtaining dependencies
    Given I specify that testable instances use a default dependency
    And I create a testable with a type of HasMultipleDependencies
    And I use an explicit dependency
    When I want to use the testable instance
    Then I should have a default dependency
    And I should have an explicit dependency
    And I should have a canned dependency
    And I should have a mocked dependency
