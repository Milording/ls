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
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace ABBYY_LS.Tests
{   /// <summary>
    /// Test for <see cref="MainPage"/>.
    /// </summary>
    [TestFixture]
    public class TestMainPage
    {
        #region Fields

        public RemoteWebDriver driver;

        internal MainPage mainPage;

        #endregion

        #region Setup test

        /// <summary>
        /// Invokes before every test.
        /// </summary>
        [SetUp]
        public void SetUp()
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
}
