Feature: ProfilePageCertifications
	
@mytag 
Scenario:Seller is able Add Certifications
	Given Seller is on Certifications tab
    When Seller clicks on ‘Add New’ Adds the required field on  Certifications Tab
    Then The entry is displayed in the table below on Certifications tab also a message "{certification} has been add to your certification” appears

@mytag
Scenario:Seller tries to Add already existing Certifications then error message pops up
           Given Seller is on Certifications tab to add existing  Certifications record
           When Seller clicks on ‘Add New’ adds already existing  Certifications data
           Then Clicks on ‘Add’ on Certifications tab  button an error message “This information is already exist” appears

@mytag
Scenario:Seller tries to Edit the existing entry on Certifications tab
           Given Seller is on  Certifications tab to update a record
           When Seller clicks on pencil icon on the row of  Certifications Table
           And Updates the recored  Certifications Table by clicks on ‘Update’ 
           Then The changes are reflected in the table on Certifications tab also a message “{certification} has been updated to your certification ”appears 

@mytag
Scenario:Seller tries to Delete entry on Certifications tab
           Given Seller is on  Certifications tab to delete a record
           When Seller clicks on Cross icon on the row of Certifications table
           Then The row is deleted from the table on Certifications Tab also a message “{certification} has been deleted from your certification ”appears






