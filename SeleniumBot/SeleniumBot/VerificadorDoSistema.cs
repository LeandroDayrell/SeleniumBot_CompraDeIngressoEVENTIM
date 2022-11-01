using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBot
{
    public class VerificadorDoSistema
    {
        public static bool WaiLoadPage(IWait<IWebDriver> wait)
        {
            try
            {
                wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public static bool WaitLoadUrl(IWait<IWebDriver> wait, string partialUrl)
        {
            try
            {
                wait.Until(x => x.Url.Contains(partialUrl));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public static bool WaitElementExists(IWait<IWebDriver> wait, By by)
        {
            try
            {
                wait.Until(driver => IsElementPresent(driver, by));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public static bool IsElementPresent(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsAlertPresent(IWebDriver driver)
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public static string CloseAlertAndGetItsText(IWebDriver driver, bool acceptNextAlert)
        {
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            if (acceptNextAlert)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }
            return alertText;
        }

        public static void DiscordSendMessage(string url, string mensagemTeste)
        {
            WebClient wc = new WebClient();

            try
            {
                wc.UploadValues(url, new NameValueCollection
            {
                    {
                        "content", mensagemTeste
                    },
            });
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.ToString());


            }
        }
    }
}
