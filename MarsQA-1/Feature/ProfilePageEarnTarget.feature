Feature: ProfilePageEarnTarget
	
@mytag
Scenario:Seller is able to add his Earn Target
	Given Seller is on profile Page to add Earn Target
    When Seller click on Pencil icon to add Earn Target 
	And Selects the Option form the Dropdown to add Earn Target
    Then Selected option is Added

@mytag
Scenario:Seller is able to edit his Earn Target
	Given Seller is on profile Page to edit Earn Target
    When Seller click on Pencil icon in Earn Target row
	And Selects the Option form the Dropdown
    Then Selected option is displayed
