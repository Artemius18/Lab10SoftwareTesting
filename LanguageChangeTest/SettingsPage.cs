using OpenQA.Selenium;
using System.Threading;

namespace Tests
{
    public class SettingsPage
    {
        private IWebDriver driver;

        public SettingsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ChangeLanguage()
        {
            FindSleepClickSleep(By.XPath("//*[@id=\"desktop.settings.selectLanguage\"]"));
            FindSleepClickSleep(By.XPath("//*[@id=\"desktop.settings.selectLanguage\"]/option[18]"), 1000, 3000);
        }

        public void FindSleepClickSleep(By locator, int sleepTime1 = 2000, int sleepTime2 = 1000)
        {
            IWebElement element = driver.FindElement(locator);
            Thread.Sleep(sleepTime1);
            element.Click();
            Thread.Sleep(sleepTime2);
        }
    }
}
