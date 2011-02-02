Feature: Explicit dependencies
    In order to be able to easily test classes
    As a developer
    I want to be able to specify specific depencencies to use on a testable instance

Scenario: Specify an explicit dependency to use
    Given I create a testable with a type of HasSingleDependency
    When I tell the testable object to use an explicit dependency
    And I want to use the testable instance
    Then I should have an instance that uses that explicit dependency

Scenario: Can not provide an explicit dependency that is not used by the type of the testable instance
    Given I create a testable with a type of HasSingleDependency
    When I tell the object to use a dependency it does not have
    Then I should have seen an exception with a type of ArgumentException
