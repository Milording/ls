using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ABBYY_LS.Tests.Page_objects;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace ABBYY_LS.Tests
{
    /// <summary>
    /// Tests a <see cref="TranslatorPage"/>.
    /// </summary>
    [TestFixture]
    public class TestTranslator:TestTranslatorSetup
    {

        #region Finilizer

        /// <summary>
        /// Clean up browser driver.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                driver.GetScreenshot()
                    .SaveAsFile(
                        String.Format("{0}-{1:yyyy-MM-dd_HHmmss}", TestContext.CurrentContext.Test.MethodName,
                            DateTime.Now), ImageFormat.Jpeg);
            LogFile.LogMessage(TestContext.CurrentContext);
            this.driver.Close();
        }

        #endregion

        #region Tests

        /// <summary>
        /// Selects a first language as Russian.
        /// </summary>
        [Test]
        public void _01_IsSetRussian()
        {
            var selector = translatorPage.SelectFirstLanguage(translatorPage.RussianValue);

            Assert.AreEqual(true,selector.SelectedOption.Displayed);
        }

        /// <summary>
        /// Selects a second language as English.
        /// </summary>
        [Test]
        public void _02_IsSetEnglish()
        {
            var selector = translatorPage.SelectSecondLanguage(translatorPage.EnglishValue);

            Assert.AreEqual(true,selector.SelectedOption.Displayed);
        }

        #endregion
        
    }


    /// <summary>
    /// Setup class for <see cref="TestTranslator"/>
    /// </summary>
    public class TestTranslatorSetup
    {

        #region Fields

        public RemoteWebDriver driver;

        internal TranslatorPage translatorPage;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of <see cref="TestTranslatorSetup"/>.
        /// </summary>
        public TestTranslatorSetup()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://abbyy-ls.ru/calculator");
            Thread.Sleep(1000);

            this.translatorPage = new TranslatorPage(driver);
        }

        #endregion
        
        #region Finilizer

        /// <summary>
        /// Clean up browser driver.
        /// </summary>
        ~TestTranslatorSetup()
        {
            driver.Close();
        }

        #endregion
        
    }
}
