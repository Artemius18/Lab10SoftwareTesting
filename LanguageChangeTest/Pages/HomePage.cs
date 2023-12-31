﻿using OpenQA.Selenium;
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

        public void AddSong()
        {

            //клик по плейлисту
            ClickElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[1]/nav/div[2]/div[1]/div[2]/div[4]/div/div/div/div[2]/ul/div/div[2]/li[3]/div/div[1]"));


            ////*[@id=\"main\"]/div/div[2]/div[3]/div[1]/div[2]/div[2]/div/div/div[2]/main/section/div/div[2]/div[3]/div[1]/div/div/div/div/div[2]/div[1]/div
            //клик по первому треку в плейлисте
            ClickElement(By.CssSelector("#main > div > div.ZQftYELq0aOsg6tPbVbV > div.jEMA2gVoLgPQqAFrPhFw > div.main-view-container > div.os-host.os-host-foreign.os-theme-spotify.os-host-resize-disabled.os-host-scrollbar-horizontal-hidden.main-view-container__scroll-node.os-host-transition.os-host-overflow.os-host-overflow-y > div.os-padding > div > div > div.main-view-container__scroll-node-child > main > section > div > div.BL__GuO2JsHMR6RgNfwY > div.contentSpacing > div:nth-child(1) > div > div > div > div > div:nth-child(2) > div:nth-child(1) > div"));

            
            //клик по блоку с найденной песней
            ClickElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/div[1]/div[2]/div[2]/div/div/div[2]/main/section/div/div[2]/div[3]/div[1]/div/div/div/div/div[2]/div[1]/div"));

            //клик по контекстному меню
            ClickElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/div[1]/div[2]/div[2]/div/div/div[2]/main/section/div/div[2]/div[3]/div[1]/div/div/div/div/div[2]/div[1]/div/div[4]/button[2]"));

            //нажатие на кнопку "добавить в плейлист
            ClickElement(By.XPath("//*[@id=\"context-menu\"]/ul/li[1]/button"));

            //выбор плейлиста для добавления
            ClickElement(By.XPath("/html/body/div[24]/div/ul/li[1]/div/ul/div/li[3]/button"));

        }

        public bool isSongInPlaylist()
        {
            //перешли в плейлист
            ClickElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[1]/nav/div[2]/div[1]/div[2]/div[4]/div/div/div/div[2]/ul/div/div[2]/li[1]/div/div[1]"));

            //ищем трек по css-селектору (не очень надежно, но иначе никак xd)
            return FindElement(By.CssSelector("div[data-encore-id='type'].Type__TypeElement-sc-goli3j-0.fZDcWX.t_yrXoUO3qGsJS4Y6iXX.standalone-ellipsis-one-line"));
            //return false;
        }

        public void InputSearchLength()
        {
            string actualStr = "\"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\"";
            ClickElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[1]/nav/div[1]/ul/li[2]"));
            ClickElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/header/div[3]/div/div/form/input"), actualStr);

            int searchStr = GetSearchInputLength(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/header/div[3]/div/div/form/input"));

            Assert.Greater(actualStr.Length, searchStr, $"Actual length is {actualStr.Length}. Max input length is " + searchStr);
            Assert.Less(actualStr.Length, searchStr, $"Actual length is {actualStr.Length}. Max input length is " + searchStr);
        }
        public int GetSearchInputLength(By locator)
        {
            IWebElement searchInput = driver.FindElement(locator);
            string inputValue = searchInput.GetAttribute("value");
            return inputValue.Length;
        }

    }
}
