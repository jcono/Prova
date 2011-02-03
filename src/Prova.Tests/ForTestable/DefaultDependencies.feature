Feature: Default dependencies
    In order to be able to easily test classes
    As a developer
    I want to be able to specify depencencies to use for all testable instances of a type

Scenario: Specify a type to use for a dependency for all testable instances
    Given I clear all the default dependencies for the type HasSingleDependency
    When I want all testables for the type HasSingleDependency to use the type DefaultDependency
    And I create two testables for the type HasSingleDependency
    And I want to use both the testable instances
    Then I should have two instances with different dependencies

Scenario: Specify a function to use for a dependency for all testable instances
    Given I clear all the default dependencies for the type HasSingleDependency
    When I want all testables for the type HasSingleDependency to use a function that returns the type DefaultDependency
    And I create two testables for the type HasSingleDependency
    And I want to use both the testable instances
    Then I should have two instances with different dependencies
