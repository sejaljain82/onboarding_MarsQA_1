Feature: ProfilePageEducation
	
@mytag 
Scenario:Seller is able Add Education
	Given Seller is on  Education tab
    When Seller clicks on ‘Add New’ Adds the required field on Education Tab
    Then The entry is displayed in the table below on  Education tab also a message "{Education} has been add” appears

@mytag
Scenario:Seller tries to Add already existing Education then error message pops up
           Given Seller is on  Education tab to add existing Education record
           When Seller clicks on ‘Add New’ adds already existing Education data
           Then clicks on ‘Add’on Education tab an error message “This information is already exist” appears

@mytag
Scenario:Seller tries to Edit the existing entry on Education tab
           Given Seller is on Education tab to update a record
           When Seller clicks on pencil icon on the row of Education Table
           And Updates the recored Eduction Table by clicks on ‘Update’ 
           Then The changes are reflected in the table on Education tab also a message “{Education} as been updated ”appears 

@mytag
Scenario:Seller tries to Delete entry on Education tab
           Given Seller is on Education tab to delete a record
           When Seller clicks on Cross icon on the row of Education table
           Then The row is deleted from the table on Education Tab also a message “{Education} entry successfully removed ”appears 






