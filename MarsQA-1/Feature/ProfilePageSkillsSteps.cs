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
    public class ProfilePageSkillsSteps
    {
        
        SkillsPage SkillPageObj = new SkillsPage();

        #region Add Skills
        [Given(@"Seller is on Skill tab")]
        public void GivenSellerIsOnSkillTab()
        {
            SkillPageObj.GotoSkills();
        }

        [When(@"Seller clicks on ‘Add New' Adds the required field on skill tab")]
        public void WhenSellerClicksOnAddNewAddsTheRequiredFieldOnSkillTab()
        {
            SkillPageObj.AddSkills();
        }


        [Then(@"The entry is displayed in the table below on skill Tab also a message “\{skill} has been add to your Skills” appears")]
        public void ThenTheEntryIsDisplayedInTheTableBelowOnSkillTabAlsoAMessageSkillHasBeenAddToYourSkillsAppears()
        {
            SkillPageObj.expectedmessage = SkillPageObj.SkilldatafromExcel + " has been added to your skills";
            SkillPageObj.ValidateSkillsOperations();
        }

        #endregion


        [Given(@"Seller is on Skills tab to delete Skill")]
        public void GivenSellerIsOnSkillsTabToDeleteSkill()
        {

            SkillPageObj.GotoSkills();
        }

        [When(@"Seller clicks on Cross icon on the row")]
        public void WhenSellerClicksOnCrossIconOnTheRow()
        {
            SkillPageObj.DeleteSkills(); 
        }

        [Then(@"the row is deleted from the table on Skills Tab aslo a message “\{skill} has been deleted ”appears")]
        public void ThenTheRowIsDeletedFromTheTableOnSkillsTabAsloAMessageSkillHasBeenDeletedAppears()
        {

            SkillPageObj.expectedmessage = SkillPageObj.actulSkills + " has been deleted";
            SkillPageObj.ValidateSkillsOperations();
            
        }


    }
}
