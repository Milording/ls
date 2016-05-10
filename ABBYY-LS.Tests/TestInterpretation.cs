using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ABBYY_LS.Tests.Page_objects;
using NUnit.Framework.Internal;
using NUnit.Framework;
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
    public class TestInterpretation : TestInterpretationSetup
    {

        #region Tests

        [Test]
        public void SetEvent()
        {
            var select = interpretationPage.SelectEvent(interpretationPage.TrainingEvent);

            Assert.AreEqual(interpretationPage.TrainingEvent, select.SelectedOption.Text);
        }

        #endregion

    }

    /// <summary>
    /// Setup of <see cref="TestInterpretation"/>.
    /// </summary>
    public class TestInterpretationSetup
    {

        #region Local fields

        internal RemoteWebDriver driver;

        internal InterpretationPage interpretationPage;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="TestInterpretationSetup"/>.
        /// </summary>
        public TestInterpretationSetup()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://abbyy-ls.ru/interpreting_offer");

            Thread.Sleep(3000);

            this.interpretationPage = new InterpretationPage(this.driver);
        }

        #endregion

        #region Finilizer

        /// <summary>
        /// Clean up browser data.
        /// </summary>
        ~TestInterpretationSetup()
        {
            this.driver.Close();
        }

        #endregion

    }
}
