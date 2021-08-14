using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using MarsQA_1.Helpers;
using OpenQA.Selenium;


namespace MarsQA_1.Pages
{
    class SkillsPage
    {
        public string actulSkills;
        public string actulmessage;
        public string SkilldatafromExcel;
        public string expectedmessage;
        IWebElement displayedMessage;
        IWebElement errorMessage;

        public void GotoSkills()
        {
            //Click on Skill tab
            Driver.driver.FindElement(By.XPath("(//div[contains(@class,'ui top')]//a)[2]")).Click();
            Thread.Sleep(3000);
        }

        public void AddSkills()
        {
            
            try
            {
                //click on 'Add New'button
                Driver.driver.FindElement(By.XPath("(//div[contains(@class,'ui teal')])[2]")).Click();
                Thread.Sleep(300);

                //get a random number between 2 to 6 to select the data from the file
                int i = new Random().Next(2, 6);

                //Locating the Excel file
                ExcelLibHelper.PopulateInCollection(@"C:\Sejal\MVP\onboarding.specflow-master\MarsQA-1\SpecflowTests\Data\Data.xlsx", "Skills");

                //Reading data from Execl file
                SkilldatafromExcel = ExcelLibHelper.ReadData(i, "Skill");
                var LeveldatafromExcel = ExcelLibHelper.ReadData(i, "Level");

                //Find Add Skills input box and add Skill
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input")).SendKeys(SkilldatafromExcel);

                //Find the drop down box to add Skill Level
                var SkillsLevel = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));

                //create a SelectElement object to access drop down box 
                var SelectSkillslevel = new SelectElement(SkillsLevel);

                //Set the Skills level that is ther in the Excel sheet
                SelectSkillslevel.SelectByText(LeveldatafromExcel);

                //click on 'Add' button
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")).Click();
                Thread.Sleep(5000);
            }
            catch
            {

                errorMessage = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                actulmessage = errorMessage.Text;
                Assert.Fail(actulmessage);
            }


        }

        public void DeleteSkills()
        {
            //Read and store the Skill field value of the last record in the Skills table before deleting
            actulSkills = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]")).Text;

            //Find and Click on the delete button on last recoerd of the Skills tab Table 
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]")).Click();

        }

        public void ValidateSkillsOperations()
        {
            

            //Getting the Message that is displayed in the Popup after the record is deleted from the table
            displayedMessage = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            actulmessage = displayedMessage.Text;

            //Compering  the expected and tha actul message that is displayed in the pop up
            Assert.AreEqual(expectedmessage, actulmessage);
        }
    }
}
