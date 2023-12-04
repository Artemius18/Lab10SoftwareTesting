using LanguageChangeTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Xml;

namespace LanguageChangeTest.Tests
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.OpenPage();
            loginPage.Login("artempsenko@gmail.com", "clashroyale2003");
        }


        [Test]
        public void LanguageChangeTest()
        {
            SettingsPage settingsPage = new SettingsPage(driver);
            settingsPage.OpenPage();
            settingsPage.CloseObstructingTab("//*[@id=\"main\"]/div/div[2]/div[1]/nav/div[2]/div[1]/div[3]/div/button");
            settingsPage.ChangeLanguage();
            settingsPage.isLanguageChanged();
        }


        //[Test]
        //public void AddSongToPlaylist()
        //{
        //    HomePage homePage = new HomePage(driver);
        //    homePage.OpenPage();
        //    homePage.CloseObstructingTab("//*[@id=\"main\"]/div/div[2]/div[1]/nav/div[2]/div[1]/div[3]/div/button");
        //    homePage.AddSong();
        //    Assert.IsTrue(homePage.isSongInPlaylist(), "Песни нет в плейлисте!");
        //}

        [Test]
        public void MaxInputSearchLengthTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.OpenPage();
            homePage.CloseObstructingTab("//*[@id=\"main\"]/div/div[2]/div[1]/nav/div[2]/div[1]/div[3]/div/button");
            homePage.InputSearchLength();
        }
        [TearDown]
        public void TearDown()
        {
            //try
            //{
            //    driver.Quit();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error: " + ex.Message);
            //}
        }
    }
}
