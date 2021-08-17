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
    public class ProfilePageEducationSteps
    {

        EducationPage EducationPageObj = new EducationPage();

        #region Add Education

        [Given(@"Seller is on  Education tab")]
        public void GivenSellerIsOnEducationTab()
        {
            EducationPageObj.GoToEducation();
        }

        [When(@"Seller clicks on ‘Add New’ Adds the required field on Education Tab")]
        public void WhenSellerClicksOnAddNewAddsTheRequiredFieldOnEducationTab()
        {
            EducationPageObj.AddEducation();
        }

        [Then(@"The entry is displayed in the table below on  Education tab also a message ""\{Education} has been add” appears")]
        public void ThenTheEntryIsDisplayedInTheTableBelowOnEducationTabAlsoAMessageEducationHasBeenAddAppears()
        {
            EducationPageObj.expectedmessage = "Education has been added";
            EducationPageObj.ValidateEducationOperations();
        }

        #endregion


        #region Delete Education

        [Given(@"Seller is on Education tab to delete a record")]
        public void GivenSellerIsOnEducationTabToDeleteARecord()
        {
            EducationPageObj.GoToEducation();
        }

        [When(@"Seller clicks on Cross icon on the row of Education table")]
        public void WhenSellerClicksOnCrossIconOnTheRowOfEducationTable()
        {
            EducationPageObj.DeleteEducation();
        }

        [Then(@"The row is deleted from the table on Education Tab also a message “Education entry successfully removed ”appears")]
        public void ThenTheRowIsDeletedFromTheTableOnEducationTabAlsoAMessageEducationEntrySuccessfullyRemovedAppears()
        {

            EducationPageObj.expectedmessage = "Education entry successfully removed";
            EducationPageObj.ValidateEducationOperations();
            Thread.Sleep(3000);
        }


        #endregion


        #region Update Education

        [Given(@"Seller is on Education tab to update a record")]
        public void GivenSellerIsOnEducationTabToUpdateARecord()
        {
            EducationPageObj.GoToEducation();
        }

        [When(@"Seller clicks on pencil icon on the row of Education Table to Updae the record")]
        public void WhenSellerClicksOnPencilIconOnTheRowOfEducationTableToUpdaeTheRecord()
        {
            EducationPageObj.UpdateEducation();
        }

        [Then(@"The changes are reflected in the table on Education tab also a message “Education as been updated ”appears")]
        public void ThenTheChangesAreReflectedInTheTableOnEducationTabAlsoAMessageEducationAsBeenUpdatedAppears()
        {
            EducationPageObj.expectedmessage = "Education as been updated";
            EducationPageObj.ValidateEducationOperations();
            Thread.Sleep(3000);
        }


        #endregion 
    }
}
