using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsQA_1.Helpers;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;

namespace MarsQA_1.Pages
{
    class ChangeName
    {

        private string actulename;
        private string expectedName;

        public IWebElement Fname { get; private set; }
        public IWebElement Lname { get; private set; }
        public void GotoProfilePage()
        {
            Driver.TurnOnWait();

            //Seller cliks on Profle Tab So Seller is on Proflie page
            Driver.driver.FindElement(By.XPath("(//div[contains(@class,'ui eight')]//a)[2]")).Click();

            Driver.TurnOnWait();
        }
        public void GotoName()
        {
            //Seller clicks on the Arrow to edit the name
            Driver.driver.FindElement(By.XPath("(//i[@class='dropdown icon'])[2]")).Click();
        }
        public void ChangeNameFunction()
        {

            //get a random number between 2 to 5 to select the data from the file
            int i = new Random().Next(2, 5);
            Thread.Sleep(3000);
            //Giveng the Pat of the Excel File and Name of the sheet from wher the data will be taken 
            ExcelLibHelper.PopulateInCollection(@"C:\Sejal\MVP\onboarding.specflow-master\MarsQA-1\SpecflowTests\Data\EditName.xlsx", "Name");

            //Finding the First name element  
            Fname = Driver.driver.FindElement(By.XPath("//div[@class='field']//input[1]"));
            Thread.Sleep(1000);

            //Clearing the existing data
            Fname.Clear();
            Thread.Sleep(1000);

            //Assign First name by reading it from Excel file
            string expectedFirstName = ExcelLibHelper.ReadData(i, "FirstName");
            Fname.SendKeys(expectedFirstName);

            //Finding the First name element 
            Lname = Driver.driver.FindElement(By.XPath("(//div[@class='field']//input)[2]"));
            //Clearing the existing data
            Lname.Clear();
            Thread.Sleep(1000);

            //Assign Last  name by reading it from Excel file
            string expectedLastName = ExcelLibHelper.ReadData(i, "LastName");
            Lname.SendKeys(expectedLastName);

            expectedName = expectedFirstName + " " + expectedLastName;
        }

        public void SaveName()
        {
            //Finding the Save button element and clicking it to  save the changes
            Driver.driver.FindElement(By.XPath("//div[contains(@class,'ui form')]//button[1]")).Click();
            Thread.Sleep(2000);
        }

        public void ValidateNameChange()
        {
           
            //Verifying the changes     
            actulename = Driver.driver.FindElement(By.CssSelector("div.title")).Text;

            Assert.AreEqual(expectedName, actulename);
        }
    }
}
