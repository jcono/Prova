Feature: Specify default actions to take to resolve dependencies if no explicit
    In order to be able to easily test classes
    As a developer
    I want to be able to specify default depencencies to use for all testable instances of a type

Scenario: Specify a default dependency to use on all testable instances
    Given I want to use a default dependency on all testable instances with type of HasSingleDependency
    And I create a testable with a type of HasSingleDependency
    And I create another testable with a type of HasSingleDependency
    When I want to use the testable instance
    And I want to use the other testable instance
    Then I should have two instances with different dependencies

Scenario: Change the default dependencies to use on all testable instances
    Given I want to use a default dependency on all testable instances with type of HasSingleDependency
    When I want to use a different default dependency on all testable instances with type of HasSingleDependency
    And I create a testable with a type of HasSingleDependency
    And I want to use the testable instance
    Then I should have an instance that uses a different dependency
