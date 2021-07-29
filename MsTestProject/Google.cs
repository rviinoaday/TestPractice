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

namespace MsTestProject
{
    [TestClass]
    public class Google
    {
        [TestMethod]
        public void Googelsearch()
        {
            OpenQA.Selenium.IWebDriver driver = new ChromeDriver();
           
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            OpenQA.Selenium.IJavaScriptExecutor js = driver as OpenQA.Selenium.IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,300);");
            ReadOnlyCollection<string> windows1 = driver.WindowHandles;
            driver.SwitchTo().Window(windows1[0]);
            driver.FindElement(By.XPath("//*[@id='L2AGLb']/div")).Click();
            driver.FindElement(By.XPath("//*[@type='text']")).SendKeys("how to apply loan");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@class='FPdoLc lJ9FBc']/center/input[1]")).Click();
        }
    }
}
