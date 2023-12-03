using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private string baseURL;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            baseURL = "https://open.spotify.com";

            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Window.Maximize();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("artempsenko@gmail.com", "clashroyale2003");
        }

        [Test]
        public void LanguageChangeTest()
        {
            Thread.Sleep(5000);

            //закрыть элемент, который мешает тестированию поверх экрана
            FindSleepClickSleep(By.XPath("//*[@id=\"main\"]/div/div[2]/div[1]/nav/div[2]/div[1]/div[3]/div/button"));

            FindSleepClickSleep(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/header/button[3]"));

            FindSleepClickSleep(By.XPath("//*[@id=\"context-menu\"]/div/ul/li[4]/a"));

            SettingsPage settingsPage = new SettingsPage(driver);
            settingsPage.ChangeLanguage();

            FindSleepClickSleep(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/div[1]/div[2]/div[2]/div/div/div[2]/main/div[1]/div[2]/div/div[3]/button"));
            Thread.Sleep(3000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement TextButton = wait.Until(driver => driver.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/header/button[1]")));
            Assert.That(TextButton.Text, Is.EqualTo("Explore Premium"), "Сайт не переведен на английский");
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
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
