Feature: Can provide different ways of supplying a dependency to a class
    In order to be able to use testable objects
    As a developer
    I want to be able to supply different types of dependencies

Scenario: Implicitly obtain a dependency from the loaded assemblies
    Given I create a testable with a type of HasSingleDependency
    When I want to use the testable instance
    Then I should have a dependency with a type of CannedDependency

Scenario: Implicitly obtain a dependency
    Given I create a testable with a type of HasSingleDependency
    When I want to use the testable instance
    Then I should have a dependency that is not null

