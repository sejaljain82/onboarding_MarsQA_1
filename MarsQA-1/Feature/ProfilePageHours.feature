Feature: PofilePageHours
	


	@mytag
Scenario: Seller is able to add his Hours
	Given Seller is on profile Page to add Hours
    When Seller clicks on Pencil icon to add Hours
	And Selects the Option form the Dropdown to add Hours
    Then Selected option is Added                   

@mytag
Scenario: Seller is able to edit his Hours
	Given Seller is on profile Page to edit Hours
    When Seller clicks on Pencil icon in Hours row
	And Selects the Option form the Dropdown
    Then Selected option is displayed
