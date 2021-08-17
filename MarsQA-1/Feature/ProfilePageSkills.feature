Feature: ProfilePageSkills


@mytag
Scenario:Seller is able Add Skills
	Given Seller is on Skill tab
    When Seller clicks on ‘Add New' Adds the required field on skill tab
    Then The entry is displayed in the table below on skill Tab also a message “{skill} has been add to your Skills” appears

@mytag
Scenario:Seller tries to Delete entry on Skills tab
    Given Seller is on Skills tab to delete Skill
    When Seller clicks on Cross icon on the row 
    Then the row is deleted from the table on Skills Tab aslo a message “{skill} has been deleted ”appears 

 @mytag  
 Scenario:Seller tries to Edit the existing entry on Skills tab
      Given Seller is on Skills tab to update Skills table
      When Seller clicks on pencil icon on the row on the skill table to Updates the recored 
      Then The changes are reflected in the table on Languages tab also a message “{skills} has been updated to your skills ”appears 

@mytag
Scenario:Seller tries to Add already existing Skillsthen error message pops up
           Given Seller is on   Skills tab to add existing  Skills record
           When Seller clicks on ‘Add New’ adds already existing  Skills data
           Then Clicks on ‘Add’ on Skills tab button an error message “This information is already exist” appears

            @mytag 
Scenario:Seller is able Add Skills tab
	Given Seller is on Skills tab to add data
    When Seller clicks on ‘Add New’ on Skills tab
    But clikcs on 'Add' without adding data on Skills tab
    Then A message "Please enter skills and experience level"appears 