Feature: Manage Basic Customer Registration

@CustomerRegistration
Scenario: Register Name and Last Name
	Given I have entered Name "Jessé" into the form
	And I have entered Last Name "Toledo" into the form
	When I press add
	Then the result should be the Full Name "Jessé Toledo" registered