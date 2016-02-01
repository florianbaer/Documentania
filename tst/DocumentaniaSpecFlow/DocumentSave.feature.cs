// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DocumentSave.feature.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'DocumentSave.feature.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

#region Designer generated code


#pragma warning disable

namespace DocumentaniaSpecFlow
{
    using TechTalk.SpecFlow;

    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("DocumentSave")]
    public partial class DocumentSaveFeature
    {
        private TechTalk.SpecFlow.ITestRunner testRunner;

        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add two numbers")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void AddTwoNumbers()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo(
                "Add two numbers",
                new string[] { "mytag" });
#line 7
            this.ScenarioSetup(scenarioInfo);
#line 8
            testRunner.Given(
                "I have entered 50 into the calculator",
                ((string)(null)),
                ((TechTalk.SpecFlow.Table)(null)),
                "Given ");
#line 9
            testRunner.And(
                "I have entered 70 into the calculator",
                ((string)(null)),
                ((TechTalk.SpecFlow.Table)(null)),
                "And ");
#line 10
            testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
            testRunner.Then(
                "the result should be 120 on the screen",
                ((string)(null)),
                ((TechTalk.SpecFlow.Table)(null)),
                "Then ");
#line hidden
            this.ScenarioCleanup();
        }

        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo =
                new TechTalk.SpecFlow.FeatureInfo(
                    new System.Globalization.CultureInfo("en-US"),
                    "DocumentSave",
                    "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o"
                    + "f two numbers",
                    ProgrammingLanguage.CSharp,
                    ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }

        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }

        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
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

        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
    }
}

#pragma warning restore

#endregion