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
    class EducationPage
    {

        public string CountrydatafromExcel;
        public string UniversitydatafromExcel;
        public string TitlefromExcel;
        public string DegreedatafromExcel;
        public string GraduationYeardatafromExcel;
       
        public string actulmessage;
        public string expectedmessage;
        IWebElement displayedMessage;
        IWebElement errorMessage;
      
        
        public void GoToEducation()
        {
            //Cilck on Education  Tab
            Driver.driver.FindElement(By.XPath("(//div[contains(@class,'ui top')]//a)[3]")).Click();
            Thread.Sleep(3000);
        }

        public void AddEducation()
        {

            try 
            {
                //click on 'Add New'button
                Driver.driver.FindElement(By.XPath("(//div[contains(@class,'ui teal')])[3]")).Click();
                Thread.Sleep(300);

                //get a random number between 2 to 6 to select the data from the file
                int i = new Random().Next(2, 5);

                //Locating the Excel file
                ExcelLibHelper.PopulateInCollection(@"C:\Sejal\MVP\onboarding.specflow-master\MarsQA-1\SpecflowTests\Data\Data.xlsx", "Education");

                //Reading data from Execl file

                CountrydatafromExcel = ExcelLibHelper.ReadData(i, "Country");
                UniversitydatafromExcel = ExcelLibHelper.ReadData(i, "University"); 
                TitlefromExcel = ExcelLibHelper.ReadData(i, "Title");
                DegreedatafromExcel = ExcelLibHelper.ReadData(i, "Degree");
                GraduationYeardatafromExcel = ExcelLibHelper.ReadData(i, "Graduation Year");

                //Find Add University input box and add University
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input")).SendKeys(UniversitydatafromExcel);

                //Find Add Degree input box and add Degree
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input")).SendKeys(DegreedatafromExcel);

                //Find the drop down box to add Country
                var EductaionCountry = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select"));

                //create a SelectElement object to access drop down box 
                var SelectEductaionCountry = new SelectElement(EductaionCountry);

                //Set the Country that is ther in the Excel sheet
                SelectEductaionCountry.SelectByText(CountrydatafromExcel);

                //Find the drop down box to add Title
                var EductaionTitle = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select"));

                //create a SelectElement object to access drop down box 
                var SelectEductaionTitle = new SelectElement(EductaionTitle);

                //Set the Country that is ther in the Excel sheet
                SelectEductaionTitle.SelectByText(TitlefromExcel);

                //Find the drop down box to add Title
                var EductaionGraduationYear = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select"));

                //create a SelectElement object to access drop down box 
                var SelectEductaionGraduationYear = new SelectElement(EductaionGraduationYear);

                //Set the Country that is ther in the Excel sheet
                SelectEductaionGraduationYear.SelectByText(GraduationYeardatafromExcel);

                //click on 'Add' button
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]")).Click();
           
                Thread.Sleep(5000);
        }
            catch
            {

                errorMessage = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                actulmessage = errorMessage.Text;
                Assert.Fail(actulmessage);
            }
        }


        public void UpdateEducation()
        {
             try
            {
            
            //click on 'Pencil New'button in the last row
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[1]/i")).Click();
                Thread.Sleep(300);

                //get a random number between 2 to 6 to select the data from the file
                int i = new Random().Next(10, 13);

                //Locating the Excel file
                ExcelLibHelper.PopulateInCollection(@"C:\Sejal\MVP\onboarding.specflow-master\MarsQA-1\SpecflowTests\Data\Data.xlsx", "Education");

                //Reading data from Execl file

                CountrydatafromExcel = ExcelLibHelper.ReadData(i, "Country");
                UniversitydatafromExcel = ExcelLibHelper.ReadData(i, "University");
                TitlefromExcel = ExcelLibHelper.ReadData(i, "Title");
                DegreedatafromExcel = ExcelLibHelper.ReadData(i, "Degree");
                GraduationYeardatafromExcel = ExcelLibHelper.ReadData(i, "Graduation Year");

                //Find the University box in the last row and set the Updated value 
                IWebElement UpdateUniversityBox = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td/div[1]/div[1]/input"));
                UpdateUniversityBox.Clear();
                Thread.Sleep(500);
                UpdateUniversityBox.SendKeys(UniversitydatafromExcel);

               //Find  Degree input box in the last row and set the Updated value
              IWebElement UpdateDegreeBox = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td/div[2]/div[2]/input"));
            UpdateDegreeBox.Clear();
            Thread.Sleep(500);
            UpdateDegreeBox.SendKeys(DegreedatafromExcel);

            //Find the Country drop down box in the last row and set the Updated value
            var EductaionCountry = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td/div[1]/div[2]/select"));

                //create a SelectElement object to access drop down box 
                var SelectEductaionCountry = new SelectElement(EductaionCountry);

                //Set the Country that is there in the Excel sheet
                SelectEductaionCountry.SelectByText(CountrydatafromExcel);

            //Find the  Title drop down box in the last row and set the Updated value
            var EductaionTitle = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td/div[2]/div[1]/select"));

                //create a SelectElement object to access drop down box 
                var SelectEductaionTitle = new SelectElement(EductaionTitle);

                //Set the Titel that is there in the Excel sheet
                SelectEductaionTitle.SelectByText(TitlefromExcel);

                //Find the Gartuation Year drop down box to update Title
                var EductaionGraduationYear = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td/div[2]/div[3]/select"));

                //create a SelectElement object to access drop down box 
                var SelectEductaionGraduationYear = new SelectElement(EductaionGraduationYear);

                //Set the Country that is ther in the Excel sheet
                SelectEductaionGraduationYear.SelectByText(GraduationYeardatafromExcel);

                //click on 'Update' button
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td/div[3]/input[1]")).Click();

                Thread.Sleep(5000);
            }
          catch
            {

                errorMessage = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                actulmessage = errorMessage.Text;
                Assert.Fail(actulmessage);
            }

        }



        public void DeleteEducation()
        {
            //Find and Click on the delete button on last recoerd of the Education tab Table
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]")).Click();
        }

        public void ValidateEducationOperations()
        {


            //Getting the Message that is displayed in the Popup after the record is deleted from the table
            displayedMessage = Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            actulmessage = displayedMessage.Text;

            //Compering  the expected and tha actul message that is displayed in the pop up
            Assert.AreEqual(expectedmessage, actulmessage);
        }


    }
}
