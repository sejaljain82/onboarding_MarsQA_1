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
    public class ProfilePageLanguagesSteps
    {
        string  LanguagedatafromExcel;
        string actulLanguage;
        string actulmessage;
        IWebElement displayedMessage;
        IWebElement errorMessage;

        #region Add Language

        [Given(@"Seller is on Language tab")]
        public void GivenSellerIsOnLanguageTab()
        {
            //Cilck on Language Tab
            Driver.driver.FindElement(By.XPath("//div[contains(@class,'ui top')]//a[1]")).Click();
            Thread.Sleep(3000);
        }

        [When(@"Seller clicks on ‘Add New' Adds the required field")]
        public void WhenSellerClicksOnAddNewAddsTheRequiredField() 
        {
            //click on 'Add New'button 
            Driver.driver.FindElement(By.XPath("(//div[contains(@class,'ui teal')])[1]")).Click();
            Thread.Sleep(300);
             try
            { 
                //get a random number between 2 to 5 to select the data from the file
                int i = new Random().Next(2, 5);
               
                //Locating the Excel file
                ExcelLibHelper.PopulateInCollection(@"C:\Sejal\MVP\onboarding.specflow-master\MarsQA-1\SpecflowTests\Data\Data.xlsx", "Language");
               
                //Reading data from Execl file
                 LanguagedatafromExcel = ExcelLibHelper.ReadData(i, "Language");
                var LeveldatafromExcel = ExcelLibHelper.ReadData(i, "Level");

                //Find Add Language input box and add language
                Driver.driver.FindElement(By.XPath("(//span[text()='Achiver']/following::input)[1]")).SendKeys(LanguagedatafromExcel);

               //Find the drop down box to add Language Level
                var LanguageLevel = Driver.driver.FindElement(By.Name ("level"));

                //create a SelectElement object to access drop down box 
                var SelectLanguagelevel = new SelectElement(LanguageLevel);

                //Set the Language level that is ther in the Excel sheet
                SelectLanguagelevel.SelectByText(LeveldatafromExcel);

                //click on 'Add' button
                Driver.driver.FindElement(By.XPath("(//div[contains(@class,'six wide')]//input)[1]")).Click();


            }
           catch
            {
             
                 errorMessage = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                 actulmessage = errorMessage.Text;
                 Assert.Fail(actulmessage);
            }

        }

            [Then(@"The entry is displayed in the table below onLanguages Tab")]
        public void ThenTheEntryIsDisplayedInTheTableBelowOnLanguagesTab()
        {
            
            string expectedmessage = LanguagedatafromExcel + " has been added to your languages";

            //Getting the Message that is displayed in the Popup after the record is deleted from the table
            displayedMessage = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            actulmessage = displayedMessage.Text;

            //Compering  the expected and tha actul message that is displayed in the pop up
            Assert.AreEqual(expectedmessage,actulmessage);
        }

        #endregion

        #region Delete Language

        [Given(@"Seller is on Language tab to delete Language")]
        public void GivenSellerIsOnLanguageTabToDeleteLanguage()
        {
            //Cilck on Language Tab
            Driver.driver.FindElement(By.XPath("//div[contains(@class,'ui top')]//a[1]")).Click();
            Thread.Sleep(3000);
        }

        [When(@"Seller clicks on Cross icon on the row of Language table")]
        public void WhenSellerClicksOnCrossIconOnTheRowOfLanguageTable()
        {
            //Read and store the Language field value of the last record in the Language table before deleting 
            actulLanguage = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]")).Text;

            //Find the delete button for the last row of the language table nd delet the last record 
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]")).Click();

            Thread.Sleep(4000);
        }

        [Then(@"the row is deleted from table on Languages tab also a message “\{language} has been deleted from your Languages ”appears")]
        public void ThenTheRowIsDeletedFromTableOnLanguagesTabAlsoAMessageLanguageHasBeenDeletedFromYourLanguagesAppears()
        {

            string expectedmessage = actulLanguage + " has been deleted from your languages";

          //Getting the Message that is displayed in the Popup after the record is deleted from the table 
            displayedMessage = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
             actulmessage = displayedMessage.Text;
            
            //Compering  the expected and tha actul message that is displayed in the pop up
            Assert.AreEqual(expectedmessage, actulmessage);

        }

        #endregion

        #region Update Language
        [Given(@"Seller is on Language tab to update Language table")]
        public void GivenSellerIsOnLanguageTabToUpdateLanguageTable()
        {
            //Cilck on Language Tab
            Driver.driver.FindElement(By.XPath("//div[contains(@class,'ui top')]//a[1]")).Click();
            Thread.Sleep(2000);
        }

        [When(@"Seller clicks on pencil icon on the row")]
        public void WhenSellerClicksOnPencilIconOnTheRow()
        {
            // Find and click on pencil icon to edit the last row
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]")).Click();
        }

        [When(@"upadates the record also clicks on ‘Update’")]
        public void WhenUpadatesTheRecordAlsoClicksOnUpdate()
        {
            try
            {
                //get a random number between 2 to 5 to select the data from the file
                int i = new Random().Next(10, 13);

                //Locating the Excel file
                ExcelLibHelper.PopulateInCollection(@"C:\Sejal\MVP\onboarding.specflow-master\MarsQA-1\SpecflowTests\Data\Data.xlsx", "Language");

                //Reading data from Execl file
                LanguagedatafromExcel = ExcelLibHelper.ReadData(i, "Language");
                var LeveldatafromExcel = ExcelLibHelper.ReadData(i, "Level");
                Thread.Sleep(500);

                //Find the Language box in the last row and set the Updated value 
                IWebElement UpdateLanguagebox = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[1]/input"));
                UpdateLanguagebox.Clear();
                Thread.Sleep(500);
                UpdateLanguagebox.SendKeys(LanguagedatafromExcel);


                //Find the drop down box to add Language Level
                var LanguageLevel = Driver.driver.FindElement(By.XPath("//tbody[last()]//select[@name='level']"));

                //create a SelectElement object to access drop down box 
                var SelectLanguagelevel = new SelectElement(LanguageLevel);

                //Set the Language level that is ther in the Excel sheet
                SelectLanguagelevel.SelectByText(LeveldatafromExcel);
                Thread.Sleep(1000);

                //Find and click on Update button after updating the recored 
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]")).Click();
                Thread.Sleep(2000);
            }
            catch
            {

                errorMessage = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
             actulmessage = errorMessage.Text;
                Assert.Fail(actulmessage);
            }

        }

        [Then(@"The changes are reflected in the table on Languages tab also a message “\{language} has been updated to your Languages ”appears")]
        public void ThenTheChangesAreReflectedInTheTableOnLanguagesTabAlsoAMessageLanguageHasBeenUpdatedToYourLanguagesAppears()
        {
            string expectedmessage = LanguagedatafromExcel + " has been updated to your languages";

            //Getting the Message that is displayed in the Popup after the record is deleted from the table
            displayedMessage = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            actulmessage = displayedMessage.Text;

            //Compering  the expected and tha actul message that is displayed in the pop up
            Assert.AreEqual(expectedmessage, actulmessage);
            Thread.Sleep(2000);
        }

        #endregion
    }
}
