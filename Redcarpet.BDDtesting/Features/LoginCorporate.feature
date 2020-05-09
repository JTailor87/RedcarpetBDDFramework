@Login
Feature: Member Onboarding Phase-1 Login

  Background: 
    Given User is already on Login page

  @Valid_Login
  Scenario Outline: HR User can login with valid credentials
    When Title of Login page is "<pTitle>"
    And User enters valid "<Email>" and "<Password>" and click LOGIN
    And User enters OTP and click on LOG IN
    Then User is on the "<Landing>" page
    And User clicks on "<link>" 
    Then The the user is redirected to the correct "<Dashboard>"
    | pTitle | Email                     | Password   | Landing | link           | Dashboard |
    | Home   | 4479af41f6@emailtown.club | Rubb3r@Mat | Home    | CompanyDetails | Corporates |
