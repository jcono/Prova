// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.5.0.0
//      Runtime Version:4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace Prova.Tests.ForTestable
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.5.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Specify default actions to take to resolve dependencies if no explicit")]
    public partial class SpecifyDefaultActionsToTakeToResolveDependenciesIfNoExplicitFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DefaultDependencies.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Specify default actions to take to resolve dependencies if no explicit", "In order to be able to easily test classes\nAs a developer\nI want to be able to sp" +
                    "ecify default depencencies to use for all testable instances of a type", GenerationTargetLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Specify a default dependency to use on all testable instances")]
        public virtual void SpecifyADefaultDependencyToUseOnAllTestableInstances()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Specify a default dependency to use on all testable instances", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
    testRunner.Given("I want to use a default dependency on all testable instances with type of HasSing" +
                    "leDependency");
#line 8
    testRunner.And("I create a testable with a type of HasSingleDependency");
#line 9
    testRunner.And("I create another testable with a type of HasSingleDependency");
#line 10
    testRunner.When("I want to use the testable instance");
#line 11
    testRunner.And("I want to use the other testable instance");
#line 12
    testRunner.Then("I should have two instances with different dependencies");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Change the default dependencies to use on all testable instances")]
        public virtual void ChangeTheDefaultDependenciesToUseOnAllTestableInstances()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change the default dependencies to use on all testable instances", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
    testRunner.Given("I want to use a default dependency on all testable instances with type of HasSing" +
                    "leDependency");
#line 16
    testRunner.When("I want to use a different default dependency on all testable instances with type " +
                    "of HasSingleDependency");
#line 17
    testRunner.And("I create a testable with a type of HasSingleDependency");
#line 18
    testRunner.And("I want to use the testable instance");
#line 19
    testRunner.Then("I should have an instance that uses a different dependency");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
