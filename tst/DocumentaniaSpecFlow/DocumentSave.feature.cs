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

namespace DocumentaniaSpecFlow.Tests
{
    using TechTalk.SpecFlow;

    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("DocumentSave")]
    public partial class DocumentSaveFeature
    {
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }

        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }

        private TechTalk.SpecFlow.ITestRunner testRunner;

        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo =
                new TechTalk.SpecFlow.FeatureInfo(
                    new System.Globalization.CultureInfo("en-US"),
                    "DocumentSave",
                    "\tIn order to verify the saving of scanned documents\r\n\tAs a chaotic developer\r\n\tI "
                    + "want to be sure that the repository works",
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

        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }

        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }

        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add and get a Document")]
        [NUnit.Framework.CategoryAttribute("RavenDbRepository")]
        public virtual void AddAndGetADocument()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo(
                "Add and get a Document",
                new string[] { "RavenDbRepository" });
#line 7
            this.ScenarioSetup(scenarioInfo);
#line 8
            testRunner.Given(
                "I have a RavenDB Repository",
                ((string)(null)),
                ((TechTalk.SpecFlow.Table)(null)),
                "Given ");
#line 9
            testRunner.When(
                "I add a Document to the Repository",
                ((string)(null)),
                ((TechTalk.SpecFlow.Table)(null)),
                "When ");
#line 10
            testRunner.Then(
                "I get 1 Document when i get all Documents",
                ((string)(null)),
                ((TechTalk.SpecFlow.Table)(null)),
                "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}

#pragma warning restore

#endregion