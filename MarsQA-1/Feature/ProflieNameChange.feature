Feature: ProflieNameChange
	

@mytag
Scenario:Seller is able to edit his Name 
	Given Seller is on profile Page Given Seller 
    When Seller clicks on Name
	And Does the desired changes 
    And clicks on 'Save'  	
	Then Edited name is displayed
