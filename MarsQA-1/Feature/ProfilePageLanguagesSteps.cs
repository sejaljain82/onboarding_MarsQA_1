using System;
using TechTalk.SpecFlow;
using MarsQA_1.Helpers;
using MarsQA_1.Pages;
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
       
        LanguagePage LanguagePageObj = new LanguagePage();
        #region Add Language

        [Given(@"Seller is on Language tab")]
        public void GivenSellerIsOnLanguageTab()
        {
            LanguagePageObj.GotoLanguage();
        }

        [When(@"Seller clicks on ‘Add New' Adds the required field")]
        public void WhenSellerClicksOnAddNewAddsTheRequiredField() 
        {
            LanguagePageObj.AddLanguage();
        }

        [Then(@"The entry is displayed in the table below onLanguages Tab")]
        public void ThenTheEntryIsDisplayedInTheTableBelowOnLanguagesTab()
        {
            LanguagePageObj.expectedmessage = LanguagePageObj.LanguagedatafromExcel + " has been added to your languages";
            LanguagePageObj.ValidateLanguageOperations();
          
        }

        #endregion

        #region Delete Language

        [Given(@"Seller is on Language tab to delete Language")]
        public void GivenSellerIsOnLanguageTabToDeleteLanguage()
        {
            LanguagePageObj.GotoLanguage();
        }

        [When(@"Seller clicks on Cross icon on the row of Language table")]
        public void WhenSellerClicksOnCrossIconOnTheRowOfLanguageTable()
        {
            LanguagePageObj.DeleteLanguage();
        }

        [Then(@"the row is deleted from table on Languages tab also a message “\{language} has been deleted from your Languages ”appears")]
        public void ThenTheRowIsDeletedFromTableOnLanguagesTabAlsoAMessageLanguageHasBeenDeletedFromYourLanguagesAppears()
        {
            LanguagePageObj.expectedmessage = LanguagePageObj.actulLanguage + " has been deleted from your languages";

            LanguagePageObj.ValidateLanguageOperations();

        }

        #endregion

        #region Update    
        
        [Given(@"Seller is on Language tab to update Language table")]
        public void GivenSellerIsOnLanguageTabToUpdateLanguageTable()
        {
            LanguagePageObj.GotoLanguage();
        }
        
        [When(@"Seller clicks on pencil icon on the row to upadates the record also clicks on ‘Update’")]
        public void WhenSellerClicksOnPencilIconOnTheRowToUpadatesTheRecordAlsoClicksOnUpdate()
        {
            LanguagePageObj.Updatelanguage();
        }
        
        [Then(@"The changes are reflected in the table on Languages tab also a message “\{language} has been updated to your Languages ”appears")]
        public void ThenTheChangesAreReflectedInTheTableOnLanguagesTabAlsoAMessageLanguageHasBeenUpdatedToYourLanguagesAppears()
        {
            LanguagePageObj.expectedmessage =LanguagePageObj.LanguagedatafromExcel + " has been updated to your languages";
            LanguagePageObj.ValidateLanguageOperations();
        }



        #endregion 
    }
}
