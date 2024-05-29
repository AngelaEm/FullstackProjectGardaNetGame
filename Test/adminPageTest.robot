*** Settings ***
Library     SeleniumLibrary
Library     DateTime
Library     Collections
Resource    masterResourceFile.robot
Suite Setup    Open Chrome browser


*** Test Cases ***

Test - signing in as Admin
    [Documentation]
    Set Selenium Speed    0.3
    I assure I am Logged In    ${ADMIN}    ${ADMINPASSWORD}
    Verify I am logged in as Admin
    Log out
   

Test - signing out 
    [Documentation]
    Set Selenium Speed    0.3 
    I assure I am Logged In    ${CustomerEmail}    ${CustomerPassword}
    I Assure I Am Logged Out
    Verify that I am now logged out
    I assure I am Logged In    ${ADMIN}    ${ADMINPASSWORD}
    I Assure I Am Logged Out
    Verify that I am now logged out

Test - As a logged in Admin I can manage events
    [Documentation]
    Set Selenium Speed    0.3
    I assure I am Logged In    ${ADMIN}    ${ADMINPASSWORD}
    Wait Until Element Is Visible    ${dropDownMenu}
    Click Element    ${dropDownMenu}
    Element Should Be Visible    ${ManageWebsiteTab}

