using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace ABBYY_LS.Tests.Page_objects
{

    /// <summary>
    /// Translator page object.
    /// </summary>
    public class TranslatorPage
    {

        #region Locators

        readonly By firstSelectorLocator = By.XPath("//*[@id='main']/form/div[2]/select[1]");
        readonly By secondSelectorLocator = By.XPath("//*[@id='main']/form/div[2]/select[2]");

        #endregion

        #region Page values

        public string EnglishValue => "en";
        public string RussianValue => "ru";

        #endregion

        #region Drivers

        /// <summary>
        /// Browser driver for page manipuluting.
        /// </summary>
        private RemoteWebDriver driver;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance of <see cref="TranslatorPage"/>.
        /// </summary>
        /// <param name="driver">Using web driver</param>
        public TranslatorPage(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Selects a first language.
        /// </summary>
        public SelectElement SelectFirstLanguage(string value)
        {
            var selector = new SelectElement(driver.FindElement(firstSelectorLocator));
            selector.SelectByValue(value);

            return selector;
        }

        /// <summary>
        /// Selects a second language.
        /// </summary>
        public SelectElement SelectSecondLanguage(string value)
        {
            var selector = new SelectElement(driver.FindElement(secondSelectorLocator));
            selector.SelectByValue(value);

            return selector;
        }

        #endregion

    }
}
