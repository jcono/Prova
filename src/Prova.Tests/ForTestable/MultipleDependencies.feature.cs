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
    [NUnit.Framework.DescriptionAttribute("Can automatically provide different ways of obtaining dependencies for a type wit" +
        "h multiple dependencies")]
    public partial class CanAutomaticallyProvideDifferentWaysOfObtainingDependenciesForATypeWithMultipleDependenciesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "MultipleDependencies.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Can automatically provide different ways of obtaining dependencies for a type wit" +
                    "h multiple dependencies", "In order to be able to use complex testable objects\nAs a developer\nI want differe" +
                    "nt ways to be obtain dependencies", GenerationTargetLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Support multiple different ways of obtaining dependencies")]
        public virtual void SupportMultipleDifferentWaysOfObtainingDependencies()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Support multiple different ways of obtaining dependencies", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
    testRunner.Given("I specify that testable instances use a default dependency");
#line 8
    testRunner.And("I create a testable with a type of HasMultipleDependencies");
#line 9
    testRunner.And("I use an explicit dependency");
#line 10
    testRunner.When("I want to use the testable instance");
#line 11
    testRunner.Then("I should have a default dependency");
#line 12
    testRunner.And("I should have an explicit dependency");
#line 13
    testRunner.And("I should have a canned dependency");
#line 14
    testRunner.And("I should have a mocked dependency");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
