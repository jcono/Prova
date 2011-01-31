Feature: Restrict the types that testable can create
    In order to diagnose problems quickly
    As a person running tests
    I want to be told if I've used an invalid type

Scenario: Can use a type with only a static constructor
    When I try and create a testable with type of HasStaticConstructor
    Then I should have a testable instance with type of HasStaticConstructor
    
Scenario: Can use a type without an explicit constructor
    When I try and create a testable with type of HasNoExplicitConstructor
    Then I should have a testable instance with type of HasNoExplicitConstructor

Scenario: Can not use an abstract type
    When I try and create a testable with type of AbstractClass
    Then I should have seen an exception with a type of ArgumentException

Scenario: Can not use a type with an ambiguous constructor
    When I try and create a testable with type of AmbiguousConstructor
    Then I should have seen an exception with a type of ArgumentException

Scenario: Can not use a type with too many constructors
    When I try and create a testable with type of HasTooManyConstructors
    Then I should have seen an exception with a type of ArgumentException
