Feature: Can provide different ways of supplying a dependency to a class
	In order to be able to use testable objects
	As a developer
	I want to be able to supply different types of dependencies

Scenario: Implicitly obtain a dependency from the loaded assemblies
	Given I have a testable with a type of HasSingleDependency
	When I use the testable object
	Then I should have a dependency with a type of CannedDependency

Scenario: Specify an explicit dependency to use
	Given I have a testable with a type of HasSingleDependency
	When I tell the testable object to use an explicit dependency
	And I use the testable object
	Then I should have an instance that uses that explicit dependency

Scenario: Specify a default dependency to use on all testable instances
	Given I want to use a default dependency
	And I have a testable with a type of HasSingleDependency
	And I have another testable with a type of HasSingleDependency
	When I use the testable object
	And I use the other testable object
	Then I should have two instances with different dependencies

Scenario: Should not be able to provide a dependency that is not used
	Given I have a testable with a type of HasSingleDependency
	When I tell the object to use a dependency it does not have
	Then I should have seen an exception with type of ArgumentException
