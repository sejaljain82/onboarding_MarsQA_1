Feature: ProfilePageLanguages
	
@mytag
Scenario:Seller is able Add Languages
	Given Seller is on Language tab
    When Seller clicks on ‘Add New' Adds the required field 
    Then The entry is displayed in the table below onLanguages Tab

@mytag
Scenario:Seller tries to Delete entry on Languages tab
           Given Seller is on Language tab to delete Language
           When Seller clicks on Cross icon on the row of Language table
           Then the row is deleted from table on Languages tab also a message “{language} has been deleted from your Languages ”appears 

@mytag          
 Scenario:Seller tries to Edit the existing entry on Languages tab
      Given Seller is on Language tab to update Language table
      When Seller clicks on pencil icon on the row to upadates the record also clicks on ‘Update’
      Then The changes are reflected in the table on Languages tab also a message “{language} has been updated to your Languages ”appears 


      @mytag
Scenario:'AddNew' buttion is hidden After Seller has add Fourth Languages Record
       Given Three recodes are already present in the Languages table
       When Fourth Language record is add sucessfully 
       Then The'Add New' gets hidden
@mytag
 Scenario:Seller tries to Add already existing language then error message pops up
      Given Seller is on Language tab ties to add existing Language record
      When Seller clicks on ‘Add New’ tries to add already existing Language data
      Then an error message ”Duplicate Data” appears
 

 @mytag 
Scenario:Seller is able Add Language tab
	Given Seller is on Language tab to add data
    When Seller clicks on ‘Add New’ on Language tab
    But clikcs on 'Add' without adding data on Language tab
    Then A message "Please enter language and level"appears  
	  

