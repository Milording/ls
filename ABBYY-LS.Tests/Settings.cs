using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace ABBYY_LS.Tests
{
    public class Settings
    {
        public static readonly RemoteWebDriver WebDriver = new FirefoxDriver();
    }
}
