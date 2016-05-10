using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ABBYY_LS.Tests.Page_objects;
using NUnit.Framework;
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

        public static RemoteWebDriver Driver;

        internal TranslatorPage translatorPage;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of <see cref="TestTranslatorSetup"/>.
        /// </summary>
        public TestTranslatorSetup()
        {
            Driver = new FirefoxDriver();
            Driver.Navigate().GoToUrl("http://abbyy-ls.ru/calculator");
            Thread.Sleep(1000);

            this.translatorPage = new TranslatorPage(Driver);
        }

        #endregion
        
        #region Finilizer

        /// <summary>
        /// Clean up browser driver.
        /// </summary>
        ~TestTranslatorSetup()
        {
            Driver.Close();
        }

        #endregion
        
    }
}
