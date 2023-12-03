using OpenQA.Selenium;
using System.Threading;

namespace Tests
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Login(string email, string password)
        {
            FindSleepClickSleep(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/header/div[5]/button[2]"));

            FindSleepClickSleep(By.XPath("//*[@id=\"login-username\"]"), "artempsenko@gmail.com", 1000, 1000);

            FindSleepClickSleep(By.XPath("//*[@id=\"login-password\"]"), "clashroyale2003", 1000, 1000);

            FindSleepClickSleep(By.XPath("//*[@id=\"login-button\"]"), 1000, 3000);
        }

        public void FindSleepClickSleep(By locator, int sleepTime1 = 2000, int sleepTime2 = 1000)
        {
            IWebElement element = driver.FindElement(locator);
            Thread.Sleep(sleepTime1);
            element.Click();
            Thread.Sleep(sleepTime2);
        }

        //перегруженный для входа, где еще в форме нужно заполнять поля
        public void FindSleepClickSleep(By locator, string sedkeysText, int sleepTime1 = 2000, int sleepTime2 = 1000)
        {
            IWebElement element = driver.FindElement(locator);
            Thread.Sleep(sleepTime1);
            element.Click();
            Thread.Sleep(sleepTime2);
            element.SendKeys(sedkeysText);
        }

    }
}
