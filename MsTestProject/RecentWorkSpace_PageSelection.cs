using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using AutoPaginationSystem;

namespace AutoPaginationSystem
{
   // [TestClass]
    public class RecentWorkSpace_PageSelection
    {
    // [TestMethod]
        public void NavigateToRecentWorkspacePageSelection(OpenQA.Selenium.IWebDriver driver)
        {
            driver.Navigate().Refresh();
            OpenQA.Selenium.IJavaScriptExecutor js = driver as OpenQA.Selenium.IJavaScriptExecutor;
            Thread.Sleep(2000);
            js.ExecuteScript("window.scrollBy(0,900);");
            Thread.Sleep(6000);
            driver.FindElement(By.Id("column-ref")).Click();
            driver.FindElement(By.XPath("//div[contains(text(),'Automation Test')]")).Click();
          
            Console.WriteLine("\n\n Naviageted successfully to Recentworkspace\n\n");
       
            Assert.IsTrue(driver.Title.Contains("Auto-Pagination Software"));
            Thread.Sleep(10000);
            Assert.IsTrue(driver.FindElement(By.XPath("//b[contains(text(),'Document: 364906G1_14.pdf')]")).Displayed);
            Console.WriteLine("\n\n FileName Match successfully \n\n");
            Assert.IsTrue(driver.FindElement(By.ClassName("nav-link")).Displayed);
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("//ul[@class='nav nav-tabs']/li[1]")).Click();
            //driver.FindElement(By.XPath("//body/div[@id='root']/div[1]/div[1]/aside[1]/ul[1]/li[1]/a[1]/i[1]")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@type='search']")).Clear();
            driver.FindElement(By.XPath("//input[@type='search']")).SendKeys("consent");
            driver.FindElement(By.XPath("//*[@id='searcher']")).Click();
            Thread.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.XPath("//b[contains(text(),'25 matches returned.')]")).Displayed);

            Console.WriteLine("\n\n Search Result successfully \n\n");
            // Below Xpath is for Target Locator "Computerised Records"
           // driver.FindElement(By.XPath("//*[@id='workspace-nav-scrollbar']/ul/li[7]/ul/li[1]/a").
            //driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div/ul/li[7]/ul/li[1]")).Click();
            Actions act = new Actions(driver);
            IWebElement src = driver.FindElement(By.XPath("//*[@id='thumbnail-container']/div/div[1]/div[1]"));
            IWebElement trg = driver.FindElement(By.XPath("//*[@id='workspace-nav-scrollbar']/ul/li[7]/ul/li[1]/a"));
            act.DragAndDrop(src, trg).Build().Perform();
            Thread.Sleep(3000);

            Console.WriteLine("\n\n Drag Sourch file  successfully to target Folder \n\n");



        }
    }
}
