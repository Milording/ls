using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ABBYY_LS.Tests.Page_objects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace ABBYY_LS.Tests
{   /// <summary>
    /// Test for <see cref="MainPage"/>.
    /// </summary>
    [TestFixture]
    public class TestMainPage : TestMainSetup
    {
        //this.driver.GetScreenshot().SaveAsFile(DateTime.Now + index + "_TestMainPage.jpg", ImageFormat.Jpeg);
        #region Tests

        [Test]
        public void PageIsLoaded()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 3));
            Assert.AreEqual(true, wait.Until(ExpectedConditions.ElementExists(By.Id("block-block-81"))).Displayed);
        }

        [Test]
        public void SmartIsWork()
        {
            mainPage.SetMenuSelector(mainPage.SmartMenuElement);
            Assert.AreEqual(true, mainPage.SmartImage.Displayed);
        }


        [Test]
        public void CostReductionIsWork()
        {
            mainPage.SetMenuSelector(mainPage.CostMenuElement);
            Assert.AreEqual(true, mainPage.CostImage.Displayed);
        }

        [Test]
        public void InnovationIsWork()
        {
            mainPage.SetMenuSelector(mainPage.InnovationMenuElement);
            Assert.AreEqual(true, mainPage.InnovationImage.Displayed);
        }

        [Test]
        public void QualityIsWork()
        {
            mainPage.SetMenuSelector(mainPage.QualityMenuElement);
            Assert.AreEqual(true, mainPage.QualityiImage.Displayed);
        }

        [Test]
        public void AutomationIsWork()
        {
            mainPage.SetMenuSelector(mainPage.AutomationMenuElement);
            Assert.AreEqual(true, mainPage.AutomationImage.Displayed);
        }
        
        #endregion

    }

    /// <summary>
    /// Setup for test of <see cref="TestMainPage"/>.
    /// </summary>
    public class TestMainSetup
    {
        #region Fields

        public RemoteWebDriver driver;

        internal MainPage mainPage;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance of <see cref="TestMainSetup"/>.
        /// </summary>
        public TestMainSetup()
        {
            this.driver = new FirefoxDriver();
            this.driver.Navigate().GoToUrl("http://abbyy-ls.ru/");
            Thread.Sleep(1000);

            this.mainPage = new MainPage(this.driver);
        }

        #endregion

        #region Finilizer

        /// <summary>
        /// Clean up browser driver.
        /// </summary>
        ~TestMainSetup()
        {
            this.driver.Close();
        }

        #endregion
    }
}
