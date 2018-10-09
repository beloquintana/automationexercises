using Applitools.Selenium;
using AutomationFramework.Handler;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;

namespace AutomationFramework.TestCase
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver;
        protected string Url = ConfigurationManager.AppSettings["Url"];

        public void BeforeBaseTest()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(Url);
        }

        public void AfterBaseTest()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }
    }
}
