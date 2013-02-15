﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.17929
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

#region Designer generated code

using TechTalk.SpecFlow;

#pragma warning disable

namespace Prova.Tests.ForTestable
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Default dependencies")]
    public partial class DefaultDependenciesFeature
    {
        private static TechTalk.SpecFlow.ITestRunner testRunner;

#line 1 "DefaultDependencies.feature"
#line hidden

        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            var featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"),
                                                                "Default dependencies",
                                                                "  In order to be able to easily test classes\n  As a developer\n  I want to be able" +
                                                                " to specify depencencies to use for all testable instances of a type",
                                                                ProgrammingLanguage.CSharp, ((string[]) (null)));
            testRunner.OnFeatureStart(featureInfo);
        }

        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }

        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }

        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }

        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }

        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }

        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Specify a type to use for a dependency for all testable instances")]
        public virtual void SpecifyATypeToUseForADependencyForAllTestableInstances()
        {
            var scenarioInfo =
                new TechTalk.SpecFlow.ScenarioInfo("Specify a type to use for a dependency for all testable instances",
                                                   ((string[]) (null)));
#line 6
            this.ScenarioSetup(scenarioInfo);
#line 7
            testRunner.Given("I clear all the default dependencies for the type HasSingleDependency", ((string) (null)),
                             ((TechTalk.SpecFlow.Table) (null)), "Given ");
#line 8
            testRunner.When("I want all testables for the type HasSingleDependency to use the type Dependency",
                            ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "When ");
#line 9
            testRunner.And("I create two testables for the type HasSingleDependency", ((string) (null)),
                           ((TechTalk.SpecFlow.Table) (null)), "And ");
#line 10
            testRunner.And("I want to use both the testable instances", ((string) (null)),
                           ((TechTalk.SpecFlow.Table) (null)), "And ");
#line 11
            testRunner.Then("I should have two instances with different dependencies of type Dependency",
                            ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }

        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Specify a function to use for a dependency for all testable instances")]
        public virtual void SpecifyAFunctionToUseForADependencyForAllTestableInstances()
        {
            var scenarioInfo =
                new TechTalk.SpecFlow.ScenarioInfo(
                    "Specify a function to use for a dependency for all testable instances", ((string[]) (null)));
#line 13
            this.ScenarioSetup(scenarioInfo);
#line 14
            testRunner.Given("I clear all the default dependencies for the type HasSingleDependency", ((string) (null)),
                             ((TechTalk.SpecFlow.Table) (null)), "Given ");
#line 15
            testRunner.When("I want all testables for the type HasSingleDependency to use a function that retu" +
                            "rns the type Dependency", ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "When ");
#line 16
            testRunner.And("I create two testables for the type HasSingleDependency", ((string) (null)),
                           ((TechTalk.SpecFlow.Table) (null)), "And ");
#line 17
            testRunner.And("I want to use both the testable instances", ((string) (null)),
                           ((TechTalk.SpecFlow.Table) (null)), "And ");
#line 18
            testRunner.Then("I should have two instances with different dependencies of type Dependency",
                            ((string) (null)), ((TechTalk.SpecFlow.Table) (null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}

#pragma warning restore

#endregion
