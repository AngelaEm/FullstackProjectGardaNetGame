
*** Settings ***
Library     SeleniumLibrary
Library     DateTime
Library     Collections
Resource    masterResourceFile.robot

Suite Setup    Open Chrome browser



*** Test Cases ***

Test - Clicking logotype redirects you to start page
    [Documentation]
    Set Selenium Speed    0.3
    Given I am at the event overview
    When I press the logotype in the top left corner
    Then I will be redirected to the Home page
    

Test - Login tab takes you to login page
    [Documentation]
    Set Selenium Speed    0.3
    Given I am at the Home Page
    When I click LogInTab
    Then the login page should be shown
    

Test - redirecting navbar
    [Documentation]
    Set Selenium Speed    0.3
    Given I am at the Home Page
    When I click on the Event tab
    Then I am redirected to the event overview
    And I can see active events
    

Test - redirecting to store
    [Documentation]
    Set Selenium Speed    0.3
    Given I am at the Home Page
    When I click the Store
    Then I am at the product overview

Test - Redirect To Faq
    [Documentation]
    Set Selenium Speed    0.3
    Given I am at the Home Page
    When I click the Faq
    Then I Am Redirected to The Faq

Test - Quetions In Faq
    [Documentation]
    Set Selenium Speed    0.3
    Given That I Am at The Faq
    When I Click A Question
    Then I See The Question

#Test - Ask A Question In Faq
#    [Documentation]
#    Set Selenium Speed    0.3
#    Given That I Am at The Faq
#    When I Ask A Question

#Test - Clicking Facebook Link
#    I am at the Home Page
#    When I Click The Facebook Link
#    Then I Should Be At Facebook

Test - Creating A customer Account

    Given That I Am At the Sign in Page
    When I Sign up As New Customer
    Then I am Registered

Test - Removing An Account
    Given That I Am At Manage Account page
    Then I Remove The Account
    Then I am at the Home Page
    Then User Is Removed








