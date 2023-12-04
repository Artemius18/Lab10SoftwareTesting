using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace LanguageChangeTest.Pages
{
    public class LoginPage : AbstractPage
    {
        private string URL = "https://accounts.spotify.com/ru/login";

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
        }

        public void Login(string email, string password)
        {
            //ClickElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/header/div[5]/button[2]"));

            ClickElement(By.XPath("//*[@id=\"login-username\"]"), email, 1000, 1000);

            ClickElement(By.XPath("//*[@id=\"login-password\"]"), password, 1000, 1000);

            ClickElement(By.XPath("//*[@id=\"login-button\"]"), 1000, 3000);

            CloseObstructingTab("//*[@id=\"root\"]/div/div[2]/div/div/button[2]");
        }

    }
}