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
        public EmployeePage(IWebDriver driver)
        {
            Driver = driver;

            if (Driver.Title.Equals("AUT From"))
                throw new Exception("This is not the Employee page");
        }
    }
}
