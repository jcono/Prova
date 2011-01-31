Feature: Check for invalid dependencies
	In order to diagnose problems quickly
	As a person running tests
	I want to be told if I've used an invalid dependency

@Invalid_Dependencies
Scenario: Should not be able to provide a dependency that can not be injected
	Given I have a testable HasSingleDependency
	When I tell the object to use an incorrect dependency
	Then I should have seen an ArgumentException
