using OpenQA.Selenium;
using System;

namespace AutomationFramework.PO
{
    public class LoginPage : BasePage
    {
        protected By UserInput = By.Id("user");
        protected By PasswordInput = By.Id("pass");
        protected By LoginButon = By.Id("loginButton");
                
        public LoginPage(IWebDriver driver)
        {
            Driver = driver;

            if (Driver.Title.Equals("AUT Login"))
                throw new Exception("This is not the login page");
        }

        public void TypeUserName(string user)
        {
            Driver.FindElement(UserInput).SendKeys(user);
        }

        public void TypePassword(string password)
        {
            Driver.FindElement(PasswordInput).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            Driver.FindElement(LoginButon).Click();
        }

        public EmployeePage LoginAs(string user, string password)
        {
            TypeUserName(user);
            TypePassword(password);
            ClickLoginButton();
            return new EmployeePage(Driver);
        }
    }
}
