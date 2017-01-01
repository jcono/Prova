Feature: Type restriction
    In order to diagnose problems quickly
    As a person running tests
    I want to be told if I've used an invalid type

Scenario: Can use a type with only a static constructor
    When I create a testable for a type HasStaticConstructor
    Then I should have an instance with that has a type HasStaticConstructor
    
Scenario: Can use a type without an explicit constructor
    When I create a testable for a type HasNoExplicitConstructor
    Then I should have an instance with that has a type HasNoExplicitConstructor

Scenario: Can not use an abstract type
    When I create a testable for a type AbstractClass
    Then I should have seen an exception with a type ArgumentException

Scenario: Can not use a type with an ambiguous constructor
    When I create a testable for a type AmbiguousConstructor
    Then I should have seen an exception with a type ArgumentException

Scenario: Can not use a type with too many constructors
    When I create a testable for a type HasTooManyConstructors
    Then I should have seen an exception with a type ArgumentException
