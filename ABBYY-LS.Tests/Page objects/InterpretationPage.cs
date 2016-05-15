using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        #region Singletone

        private static InterpretationPage instance = null;
        private static readonly object padlock = new object();

        #endregion

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

        public string PageUrl => "http://abbyy-ls.ru/interpreting_offer";

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new instance of <see cref="InterpretationPage"/>.
        /// </summary>
        /// <param name="driver"></param>
        InterpretationPage(RemoteWebDriver driver)
        {
            this.driver = driver;
            this.driver.Navigate().GoToUrl(this.PageUrl);

            Thread.Sleep(3000);
        }

        #endregion

        #region Public methods
        
        /// <summary>
        /// Returns a singltone of <see cref="InterpretationPage"/>
        /// </summary>
        public static InterpretationPage GetPage(RemoteWebDriver driver)
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new InterpretationPage(driver);
                }
                return instance;
            }
        }

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
