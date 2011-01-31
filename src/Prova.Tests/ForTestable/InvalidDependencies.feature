Feature: Check for invalid dependencies
    In order to diagnose problems quickly
    As a person running tests
    I want to be told if I've used an invalid dependency

Scenario: Should not be able to provide a dependency that can not be injected
	Given I have a testable with a type of HasSingleDependency
	When I tell the object to use an incorrect dependency
	Then I should have seen an exception with type of ArgumentException
