Feature: Login with valid and invalid credentials

	//@DataSource:..\TestData\ReportPart.xlsx
	@Testers
	Scenario: Login with valid credentials
		Given Login with credentials <UserName> and <Password>
		Then Verify home page is dispalyed
	
		Examples:
			| UserName| Password  |
			| Edward | ice4dmin |

	@Testers
	Scenario: Login with invalid credentials
		Given Login with credentials <UserName> and <Password>
		Then Verify invalid credential message is displaying

		Examples:
			| UserName | Password |
			| Ram      | Ice4dmin |
			