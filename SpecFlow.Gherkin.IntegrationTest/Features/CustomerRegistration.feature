Feature: Manage Basic Customer Registration

@CustomerRegistration
Scenario: Register Name and Last Name
	Given I have entered Name Jessé into the form
	And I have entered Last Name Toledo into the form
	And I have entered Document 969.589.890-40 into the form
	When I press add
	Then the result should be the Full Name registered

@CustomerRegistration
Scenario: Unregistered Name and Last Name
	Given I have entered Name <Name> into the form
	And I have entered Last Name <LastName> into the form
	And I have entered Document <Document> into the form
	When I press add
	Then the result should be the Full Name unregistered

	Examples:
		| Name   | LastName | Document       |
		| <null> | Toledo   | 086.813.430-92 |
		| Jessé  | <null>   | 961.915.160-70 |
		| Jessé  | Toledo   | <null>         |
		| <null> | <null>   | <null>         |