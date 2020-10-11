Feature: Apsrtc

@Login  @Smoke  @Regression
Scenario: Apsrtc Login
	Given I Called APSRTC Website
	When I Give the User Details like UserName and PassWord
	Then I Should be Logged in Successfully

@Login  @Smoke  @Regression
Scenario: Apsrtc Login With Data
	Given I Called APSRTC Website
	When I Give the User Details like "nag" and "oct123"
	Then I Should be Logged in Successfully