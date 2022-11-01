using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBot
{
    public class AutomationWeb
    {

        public IWebDriver driver;

        public AutomationWeb()
        {
            driver = new ChromeDriver();
        }

        string linkCheckout = "https://www.eventim.com.br/checkout.html?affiliate=BR1&doc=cart&language=pt#/shopping-cart";
        string linkSiteCompra = "https://www.eventim.com.br/event/coldplay-rio-de-janeiro-estadio-nilton-santos-engenhao-15185239/";



        public void TestWeb()
        {
        //driver.Navigate().GoToUrl("https://www.eventim.com.br/event/coldplay-rio-de-janeiro-estadio-nilton-santos-engenhao-15185239/");
        driver.Navigate().GoToUrl("https://www.eventim.com.br/event/def-leppard-moetley-cruee-def-leppard-moetley-cruee-sao-paulo-allianz-parque-16027908/");
        
            Thread.Sleep(3000);

            EsperarCarregamentoPagina(driver);

            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("botoes = document.getElementsByClassName(\'btn btn-alternative btn-sm btn-stepper-right theme-btn-alt js-tracking js-stepper-more js-focus-trigger\');\r\nfor (var i = 0; i < botoes.length; i++)\r\n{\r\n    botoes[i].click()\r\n}");

            Thread.Sleep(1500);

        ((IJavaScriptExecutor)driver).ExecuteScript("botoes = document.getElementsByClassName(\'btn btn-primary btn-lg btn-block theme-btn js-stepper-action js-cat-check-trigger js-cc-submit-btn\');\r\nfor (var i = 0; i < botoes.length; i++)\r\n{\r\n    botoes[i].click()\r\n}");

        Thread.Sleep(6000);


            if (WaitLoadUrl(driver, linkCheckout))
            {
                Console.WriteLine("Visao, site abriu irmão");
                Console.ReadLine(); 
            }
            else
            {
                TestWeb();
                Console.WriteLine("TENTANDO NOVAMENTE");
            }





            ///driver.Contains("", driver.Title);

            //driver.FindElement(By.Name("q")).SendKeys("Hello World");
            // clicar em inteira
            //driver.FindElement(By.XPath("//*[@id=\'tickets-bestseat-tab\']/div[1]/div/div[6]/div/form/div[2]/div/div/div[1]/div/div[2]/div/button[2]")).Click();
            //// clicar em meia
            //driver.FindElement(By.XPath("//*[@id=\'tickets-bestseat-tab\']/div[1]/div/div[6]/div/form/div[2]/div/div/div[2]/div[1]/div/div[2]/div/button[2]")).Click();


            //var text = driver.FindElement(By.XPath("//*[@id=\'rso\']/div[3]/div/div/div/div[1]/div/div/div[2]/div")).Text;

            //driver.FindElement(By.XPath("//*[@id=\'tsf\']/div[1]/div[1]/div[2]/div/div[2]/input")).SendKeys("Testeee");

            //driver.FindElement(By.XPath("//*[@id=\'tickets-bestseat-tab\']/div[1]/div/div[6]/div/form/div[2]/div/div/div[2]/div[2]/div/div[2]/div/button[2]")).Click();


            //return text;

        }

        public static bool EsperarCarregamentoPagina(IWebDriver driver)
        {
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public static bool WaitLoadUrl(IWebDriver driver, string url)
        {
            try
            {
                driver.Url.Contains(url);

                ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }


    }
}
