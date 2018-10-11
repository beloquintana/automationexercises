using AutomationFramework.Handler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.PO
{
    public class EmployeePage : BasePage
    {
        protected By Form = By.Id("formEmployee");
        protected By NameInput = By.XPath("//*[@id='formEmployee']/div[2]/div[1]/input");
        protected By EmailInput = By.XPath("//*[@id='formEmployee']/div[2]/div[2]/input");

        public EmployeePage(IWebDriver driver)
        {
            Driver = driver;

            if (Driver.Title.Equals("AUT From"))
                throw new Exception("This is not the Employee page");
        }
        
        public bool IsSuccessAlertPresent()
        {
            try
            {
                Driver.SwitchTo().Alert().Accept();
                return true;
            }
            catch (NoAlertPresentException)
            {
            }

            return false;
        }
    }
}
