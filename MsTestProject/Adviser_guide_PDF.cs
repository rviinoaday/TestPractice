using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AJBellTest
{
    [TestClass]

    public class Adviser_guide_PDF
    {
        public readonly object driver;

        [TestMethod]
        public void Adviserguide()
        {
            OpenQA.Selenium.IWebDriver driver = new ChromeDriver();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
            driver.Navigate().GoToUrl("https://www.investcentre.co.uk");
            driver.Manage().Window.Maximize();
            var newWindowHandle = driver.WindowHandles[0];
            Assert.IsTrue(!string.IsNullOrEmpty(newWindowHandle));
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Thread.Sleep(2000);
            driver.FindElement(By.Id("gateway-adviser")).Click();
            OpenQA.Selenium.IJavaScriptExecutor js = driver as OpenQA.Selenium.IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,1600);");
            driver.FindElement(By.XPath("//section[@id='section-4']/div/div[1]/div/div[2]/div[2]/div/div/a")).Click();
            Thread.Sleep(3000);
           //IWebElement Set<string> window=driver.WindowHandles();//parent ID 
           // Iterator<string> it window.
           // driver.SwitchTo().Window()

            driver.FindElement(By.XPath("//*[@class='grid-x']/div/p[1]/strong")).Click();

            //driver.FindElement(By.XPath("//*[@class='grid-x']/div/p[2]/strong")).Click();
            //driver.FindElement(By.XPath("//*[@class='grid-x']/div/p[3]/strong")).Click();
        }
        
    }
}