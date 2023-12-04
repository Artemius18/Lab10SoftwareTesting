using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace LanguageChangeTest.Pages
{
    public class SettingsPage : AbstractPage
    {
        private string URL = "https://open.spotify.com/preferences";
        public SettingsPage(IWebDriver driver) : base(driver)
        {
        }
        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
        }


        public void ChangeLanguage()
        {
            //раскрывающийся список для выбора языков
            ClickElement(By.XPath("//*[@id=\"desktop.settings.selectLanguage\"]"));

            //выбираем английский язык
            ClickElement(By.XPath("//*[@id=\"desktop.settings.selectLanguage\"]/option[18]"), 1000, 3000);

            //кнопка обновления страницы
            ClickElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/div[1]/div[2]/div[2]/div/div/div[2]/main/div[1]/div[2]/div/div[3]/button"));
        }

        public void isLanguageChanged()
        {
            IWebElement TextButton = driver.FindElement(By.XPath("/html/body/div[4]/div/div[2]/div[3]/div[1]/div[2]/div[2]/div/div/div[2]/main/div[1]/div[2]/h2"));
            Assert.That(TextButton.Text, Is.EqualTo("Language"), "Error: language isn't changed!");
        }
    }
}