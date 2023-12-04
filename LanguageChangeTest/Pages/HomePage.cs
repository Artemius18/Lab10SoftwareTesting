using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageChangeTest.Pages
{
    public class HomePage : AbstractPage
    {
        private string URL = "https://open.spotify.com/";
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
        }


    }
}
