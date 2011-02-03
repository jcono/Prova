Feature: Implicit dependencies
    In order to be able to easily use testable objects
    As a developer
    I want to have dependencies implicitly provided for an instance of a testable type

Scenario: Implicitly obtain a dependency
    Given I create a testable for a type of HasSingleDependency
    When I want to use the testable instance
    Then I should have a dependency that is not null

#Scenario: Implicitly obtain a dependency from the loaded assemblies
#    Given I create a testable for a type of HasSingleDependency
#    When I want to use the testable instance
#    Then I should have a dependency with a type of CannedDependency

