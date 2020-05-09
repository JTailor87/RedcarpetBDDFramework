@Login
Feature: LoginMember
	In order to view my profile 
	As a member who have accepted an offer
	I want to be able to login

	Background: 
	Given User is already on Login page

Scenario: Login with with valid credentials
	When User captures valid username and password and click login
	| username     | password        |
	| MobStgTest01 | M0bStag!ngT3sto1 |
	Then The user is taken to profile and the profile steps are displayed
