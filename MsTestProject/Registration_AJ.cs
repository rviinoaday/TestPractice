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
{[TestClass]
    public class Registration_AJ
    {
        [TestMethod]
        public void AdvisorRegistration()
        {
            OpenQA.Selenium.IWebDriver driver = new ChromeDriver();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
            driver.Navigate().GoToUrl("https://www.investcentre.co.uk");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("gateway-adviser")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@class='grid-container-x']/div[2]/nav[2]/ul/li[1]/a")).Click();
            driver.FindElement(By.Id("AdviserRegsitration_Login")).Click();
            string ActualError = driver.FindElement(By.ClassName("field-validation-error")).Text;
            string ExpectedError = "FSR number field is mandatory. Please try again.";
            Assert.AreEqual(ExpectedError, ActualError);
            Console.WriteLine(ActualError);
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys("Test");
            driver.FindElement(By.Id("AdviserRegsitration_Login")).Click();
            string ActualError1 = driver.FindElement(By.ClassName("field-validation-error")).Text;
            string ExpectedError1 = "We could not locate your firm. Please check that you have entered your FSR number correctly.";
            Assert.AreEqual(ExpectedError1, ActualError1);
            Console.WriteLine(ActualError1);
            driver.Close();
        }

    }
}
