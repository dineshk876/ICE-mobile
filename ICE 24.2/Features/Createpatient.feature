Feature: Create new patient

@Testers1
Scenario: Create new patient with all mandatory parameters
	Given user Login with ICE application
	When Select location
	And Navigate to patients
	And Click My Option
	And Click Add New Patient icon 
	And Enter Forename
	And Enter Surname
	And Enter DOB
	And Select Gender
	And Enter Address line
	And Enter Postcode
	And Click Save icon
	Then New patient demography is Created
	
	Examples:
			| UserName| Password  |
			| edward | ice4dmin |
			