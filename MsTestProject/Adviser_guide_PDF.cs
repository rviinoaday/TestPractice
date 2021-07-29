using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Thread.Sleep(2000);
            string title = driver.Title;
            Console.WriteLine(title);
            driver.FindElement(By.Id("gateway-adviser")).Click();
            OpenQA.Selenium.IJavaScriptExecutor js = driver as OpenQA.Selenium.IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,1600);");
            driver.FindElement(By.XPath("//section[@id='section-4']/div/div[1]/div/div[2]/div[2]/div/div/a")).Click();
            Thread.Sleep(3000);
                
            driver.FindElement(By.XPath("//*[@class='grid-x']/div/p[1]/strong")).Click();
            Assert.AreEqual(2, driver.WindowHandles.Count);
            ReadOnlyCollection<string> windows = driver.WindowHandles;
            driver.SwitchTo().Window(windows[1]);
                     
            string title1 = driver.Url;
            Console.WriteLine(title1);
            Thread.Sleep(2000);
            driver.Close();
            //Switch to parent window 
            driver.SwitchTo().Window(windows[0]);
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//*[@class='grid-x']/div/p[2]/strong")).Click();
            
            Thread.Sleep(2000);
            
            ReadOnlyCollection<string> windows1 = driver.WindowHandles;
            driver.SwitchTo().Window(windows1[1]);
            string title2 = driver.Url;
            Console.WriteLine(title2);
            Thread.Sleep(2000);
            driver.Close();
            //Switch to parent window 
            driver.SwitchTo().Window(windows[0]);
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("//*[@class='grid-x']/div/p[3]/strong")).Click();
            
            Thread.Sleep(2000);
            ReadOnlyCollection<string> windows2 = driver.WindowHandles;
            driver.SwitchTo().Window(windows2[1]);
            string title3 = driver.Url;
            Thread.Sleep(2000);
            Console.WriteLine(title3);
            driver.Close();
            //Switch to parent window 
            Thread.Sleep(3000);
            driver.SwitchTo().Window(windows2[0]);
            driver.Close();
        }
        
    }
}