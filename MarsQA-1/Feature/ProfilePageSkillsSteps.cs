using System;
using TechTalk.SpecFlow;
using MarsQA_1.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;



namespace MarsQA_1.Feature
{
    [Binding]
    public class ProfilePageSkillsSteps
    {
        string actulSkills;
        string actulmessage;
        string SkilldatafromExcel;
        IWebElement displayedMessage;
        IWebElement errorMessage;


        #region Add Skills
        [Given(@"Seller is on Skill tab")]
        public void GivenSellerIsOnSkillTab()
        {
            //Click on Skill tab
            Driver.driver.FindElement(By.XPath("(//div[contains(@class,'ui top')]//a)[2]")).Click();
            Thread.Sleep(3000);
        }

        [When(@"Seller clicks on ‘Add New' Adds the required field on skill tab")]
        public void WhenSellerClicksOnAddNewAddsTheRequiredFieldOnSkillTab()
        {
            //click on 'Add New'button
            Driver.driver.FindElement(By.XPath("(//div[contains(@class,'ui teal')])[2]")).Click();
            Thread.Sleep(300);
            try
            {

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



        [Then(@"The entry is displayed in the table below on skill Tab also a message “\{skill} has been add to your Skills” appears")]
        public void ThenTheEntryIsDisplayedInTheTableBelowOnSkillTabAlsoAMessageSkillHasBeenAddToYourSkillsAppears()
        {

            string expectedmessage = SkilldatafromExcel + " has been added to your skills";

            //Getting the Message that is displayed in the Popup after the record is deleted from the table
            displayedMessage = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            actulmessage = displayedMessage.Text;

            //Compering  the expected and tha actul message that is displayed in the pop up
            Assert.AreEqual(expectedmessage, actulmessage);
        }

        #endregion


        [Given(@"Seller is on Skills tab to delete Skill")]
        public void GivenSellerIsOnSkillsTabToDeleteSkill()
        {
          
            //Click on Skill tab
            Driver.driver.FindElement(By.XPath("(//div[contains(@class,'ui top')]//a)[2]")).Click();
            Thread.Sleep(3000);
        }

        [When(@"Seller clicks on Cross icon on the row")]
        public void WhenSellerClicksOnCrossIconOnTheRow()
        {
            //Read and store the Skill field value of the last record in the Skills table before deleting
            actulSkills = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]")).Text;

             //Find and Click on the delete button on last recoerd of the Skills tab Table 
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]")).Click();

        }

        [Then(@"the row is deleted from the table on Skills Tab aslo a message “\{skill} has been deleted ”appears")]
        public void ThenTheRowIsDeletedFromTheTableOnSkillsTabAsloAMessageSkillHasBeenDeletedAppears()
        {

            string expectedmessage = actulSkills + " has been deleted";

            //Getting the Message that is displayed in the Popup after the record is deleted from the table 
            displayedMessage = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            actulmessage = displayedMessage.Text;

            //Compering  the expected and tha actul message that is displayed in the pop up
            Assert.AreEqual(expectedmessage, actulmessage);
        }


    }
}
