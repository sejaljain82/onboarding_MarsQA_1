Feature: ProfilePageAvailability,feature
	



	@mytag
Scenario:Seller is able to Add his Availability
	Given Seller is on profile Page to Add Availability
    When Seller clicks on Pencil icon to add Availability
	And Selects the Option form the Dropdown to add Availability
    Then Selected option is Added


@mytag
Scenario:Seller is able to edit his Availability
	Given Seller is on profile Page to Edit Availability
    When Seller clicks on Pencil icon in the Availability row
	And Selects the Option form the Dropdown to edit Avaiiability
    Then Selected option is displayed
