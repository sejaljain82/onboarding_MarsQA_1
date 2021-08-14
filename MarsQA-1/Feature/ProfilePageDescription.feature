Feature: ProfilePageDescription
	
@mytag
Scenario:Seller is able Add Description 
	Given Seller is on profile Page
    When Seller clicks on Pencil icon next to Description tag
	And Writes the description
    And clicks on ‘Save’
    Then The Description is displayed 

 @mytag
Scenario:Seller is able Edit Description 
	Given Seller is on profile Page to edit Description
    When Seller clicks on Pencil icon next to Description tag for editing
	And Edits the description
    And clicks on ‘Save’to save the changes 
    Then the updated description is displayed 
 