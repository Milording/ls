using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace ABBYY_LS.Tests.Page_objects
{
    /// <summary>
    /// Page object of Main page.
    /// </summary>
    public class MainPage
    {

        #region Singletone

        private static MainPage instance = null;
        private static readonly object padlock = new object();

        #endregion

        #region Locators

        public IWebElement SmartImage => driver.FindElementByXPath("//*[@id='slider']/div[2]/div/div[1]");
        public IWebElement CostImage => driver.FindElementByXPath("//*[@id='slider']/div[2]/div/div[2]");
        public IWebElement InnovationImage => driver.FindElementByXPath("//*[@id='slider']/div[2]/div/div[3]");
        public IWebElement QualityiImage => driver.FindElementByXPath("//*[@id='slider']/div[2]/div/div[4]");
        public IWebElement AutomationImage => driver.FindElementByXPath("//*[@id='slider']/div[2]/div/div[5]");

        public IWebElement SmartMenuElement => driver.FindElementByXPath("//*[@id='slider']/div[1]/ul/li[1]");
        public IWebElement CostMenuElement => driver.FindElementByXPath("//*[@id='slider']/div[1]/ul/li[2]");
        public IWebElement InnovationMenuElement => driver.FindElementByXPath("//*[@id='slider']/div[1]/ul/li[3]");
        public IWebElement QualityMenuElement => driver.FindElementByXPath("//*[@id='slider']/div[1]/ul/li[4]");
        public IWebElement AutomationMenuElement => driver.FindElementByXPath("//*[@id='slider']/div[1]/ul/li[5]");

        #endregion

        #region Page values
        
        public string PageUrl => "http://abbyy-ls.ru/";

        #endregion

        #region Drivers

        /// <summary>
        /// Browser driver for page manipuluting.
        /// </summary>
        public RemoteWebDriver driver;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new instance of <see cref="MainPage"/>.
        /// </summary>
        MainPage(RemoteWebDriver driver)
        {
            this.driver = driver;
            this.driver.Navigate().GoToUrl(this.PageUrl);

            Thread.Sleep(3000);
        }

        #endregion

        #region Public methods


        /// <summary>
        /// Returns a singltone of <see cref="MainPage"/>
        /// </summary>
        public static MainPage GetPage(RemoteWebDriver driver)
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new MainPage(driver);
                }
                return instance;
            }
        }

        /// <summary>
        /// Set menu.
        /// </summary>
        /// <param name="locator">Locator for menu element/</param>
        public void SetMenuSelector(IWebElement locator)
        {
            locator.Click();
            Thread.Sleep(800);
        }

        #endregion

    }
    
}
