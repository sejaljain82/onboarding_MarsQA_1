using System;
using TechTalk.SpecFlow;
using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;

namespace MarsQA_1.Feature
{
    [Binding]
    public class ProflieNameChangeSteps
    {


        ChangeName ChangeNameObj = new ChangeName(); 

        [Given(@"Seller is on profile Page Given Seller")]
        public void GivenSellerIsOnProfilePageGivenSeller()
        {
            ChangeNameObj.GotoProfilePage();
        }
        
        [When(@"Seller clicks on Name")]
        public void WhenSellerClicksOnName()
        {

            ChangeNameObj.GotoName();
            
        }
        
        [When(@"Does the desired changes")]
        public void WhenDoesTheDesiredChanges()
        {
            ChangeNameObj.ChangeNameFunction();
        }
        
        [When(@"clicks on '(.*)'")]
        public void WhenClicksOn(string p0)
        {
            ChangeNameObj.SaveName();
        }
        
        [Then(@"Edited name is displayed")]
        public void ThenEditedNameIsDisplayed()
        {
            ChangeNameObj.ValidateNameChange();
      
        }
    }
}
