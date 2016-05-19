using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ABBYY_LS.Tests.Page_objects;
using NUnit.Framework.Internal;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace ABBYY_LS.Tests
{
    /// <summary>
    /// Tests a <see cref="InterpretationPage"/>
    /// </summary>
    [TestFixture]
    public class TestInterpretationPage
    {
        #region Fields

        private RemoteWebDriver driver;

        private InterpretationPage interpretationPage;

        #endregion

        #region Setup tests

        /// <summary>
        /// Invokes before every test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.driver = Settings.WebDriver;
            this.interpretationPage = InterpretationPage.GetPage(this.driver);
        }

        #endregion

        #region Finilizer

        /// <summary>
        /// Invokes after every test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                driver.GetScreenshot().SaveAsFile(
                    String.Format("{0}-{1:yyyy-MM-dd_HHmmss}", TestContext.CurrentContext.Test.MethodName,
                        DateTime.Now), ImageFormat.Jpeg);
            LogFile.LogMessage(TestContext.CurrentContext);
            this.driver.Close();
        }

        #endregion

        #region Tests

        [Test]
        public void SetEvent()
        {
            var select = interpretationPage.SelectEvent(interpretationPage.TrainingEvent);

            Assert.AreEqual(interpretationPage.TrainingEvent, select.SelectedOption.Text);
        }

        #endregion
    }
}
