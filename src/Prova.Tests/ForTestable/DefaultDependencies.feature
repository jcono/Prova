Feature: Default dependencies
    In order to be able to easily test classes
    As a developer
    I want to be able to specify depencencies to use for all testable instances of a type

Scenario: Specify a type to use for a dependency all testable instances
    Given I want all testables for the type of HasSingleDependency to use the type of DefaultDependency
    And I create two testables for a type of HasSingleDependency
    When I want to use both the testable instance
    Then I should have two instances with different dependencies
