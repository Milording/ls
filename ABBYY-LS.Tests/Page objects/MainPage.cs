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

        #region Drivers

        /// <summary>
        /// Browser driver for page manipuluting.
        /// </summary>
        private RemoteWebDriver driver;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new instance of <see cref="MainPage"/>.
        /// </summary>
        public MainPage(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        #endregion

        #region Public methods

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
