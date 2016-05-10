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
    /// Interpretation page object.
    /// </summary>
    public class InterpretationPage
    {

        #region Drivers

        /// <summary>
        /// Local driver for browser.
        /// </summary>
        private readonly RemoteWebDriver driver;

        #endregion

        #region Locators

        /// <summary>
        /// Locator for event selector UI element.
        /// </summary>
        private readonly By eventSelectorLocator = By.CssSelector("#edit-submitted-event-type");

        #endregion

        #region Page values

        public string TrainingEvent => "тренинг";

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new instance of <see cref="InterpretationPage"/>.
        /// </summary>
        /// <param name="driver"></param>
        public InterpretationPage(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Set event of page.
        /// </summary>
        public SelectElement SelectEvent(string eventName)
        {
            var select = new SelectElement(driver.FindElement(this.eventSelectorLocator));
            select.SelectByText(eventName);
            return select;
        }

        #endregion

    }

}
