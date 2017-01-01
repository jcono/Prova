Feature: Explicit dependencies
    In order to be able to easily test classes
    As a developer
    I want to be able to specify depencencies to use on each testable instance

Scenario: Can provide an explicit dependency to use with the testable instance
    Given I create a testable for a type HasSingleDependency
    When I tell the testable to use and instance of StubDependency as a dependency
    And I want to use the testable instance
    Then I should have an instance that uses that dependency

Scenario: Can not provide dependency that is not used by the type the testable instance
    Given I create a testable for a type HasSingleDependency
    When I tell the testable to use and instance of UnusedDependency as a dependency
    Then I should have seen an exception with a type ArgumentException
