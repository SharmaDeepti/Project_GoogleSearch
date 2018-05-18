using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace GoogleSearchProject
{
    //[TestClass]
    public class Program
    {
        //Variable declaration
        public static IWebDriver driver;
        
        //Initalize the driver
        public static IWebDriver InitializeDriver()
        {
            driver = new ChromeDriver();
            return driver;
        }

        public void FindText(string searchKey)
        {
            try
            {
                IWebElement element = driver.FindElement(By.Name("q"));
                System.Threading.Thread.Sleep(2000);
                element.SendKeys(searchKey);
                Console.WriteLine("Searching text in google");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void InitiateSearch()
        {
            IWebElement element = driver.FindElement(By.Name("q"));
            element.SendKeys(Keys.Enter);
        }

        public int GetLinksCount()
        {
            IList<IWebElement> linkElements;

            try
            {
                linkElements = driver.FindElements(By.XPath("*//h3/a"));
                Console.WriteLine("Total number of links in first search page is: " + linkElements.Count);
                return linkElements.Count;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }      

        }

        public void PrintLinkText(int location)
        {
            IList<IWebElement> linkElelemts;
            linkElelemts = driver.FindElements(By.XPath("*//h3/a"));
            if (linkElelemts.Count > location)
            {
                IWebElement exactPositionElement = linkElelemts[location - 1];

                Console.WriteLine("The text at {0} location is : " + exactPositionElement.Text, location);
            }
            else
                Console.WriteLine("No element found. The {0} location link doesn't exsist", location);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
        }
    }
}
