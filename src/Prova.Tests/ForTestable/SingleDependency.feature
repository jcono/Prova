Feature: Can provide different ways of supplying a dependency to a class with a single dependency
	In order to be able to use testable objects
	As a developer
	I want to be able to supply different types of dependencies

@Single_Dependency
Scenario: Implicitly obtain a dependency from the loaded assemblies
	Given I have a testable HasSingleDependency
	When I use the testable object
	Then I should have a dependency of type CannedDependency

@Single_Dependency
Scenario: Specify an explicit dependency to use
	Given I have a testable HasSingleDependency
	When I tell the testable object to use an explicit dependency
	And I use the testable object
	Then I should have an instance that uses that explicit dependency

@Single_Dependency
Scenario: Specify a default dependency to use on all testable instances
	Given I want to use a default dependency
	And I have a testable HasSingleDependency
	And I have another testable HasSingleDependency
	When I use the testable object
	And I use the other testable object
	Then The two instances should have different dependencies