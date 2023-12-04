using NodaTime;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageChangeTest.Pages
{
    public abstract class AbstractPage
    {
        protected IWebDriver driver;

        protected AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public abstract void OpenPage();
        
        //закрыть вкладку поверх окна, которая мешает тестированию
        public void CloseObstructingTab(string locator)
        {
            ClickElement(By.XPath(locator));
        }

        public void ClickElement(By locator, int sleepTime1 = 2000, int sleepTime2 = 1000)
        {
            IWebElement element = driver.FindElement(locator);
            Thread.Sleep(sleepTime1);
            element.Click();
            Thread.Sleep(sleepTime2);
        }

        //перегруженный метод для входа, где еще в форме нужно заполнять поля
        public void ClickElement(By locator, string sedkeysText, int sleepTime1 = 2000, int sleepTime2 = 1000)
        {
            IWebElement element = driver.FindElement(locator);
            Thread.Sleep(sleepTime1);
            element.Click();
            Thread.Sleep(sleepTime2);
            element.SendKeys(sedkeysText);
        }
        
        public bool FindElement(By locator)
        {
            IWebElement element = driver.FindElement(locator);
            return element != null;
        }
    }
}
