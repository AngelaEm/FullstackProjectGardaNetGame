*** Settings ***
Library     SeleniumLibrary
Library     DateTime
Library     Collections
Resource    masterResourceFile.robot


*** Keywords ***
Verify I am logged in as Admin
    Wait until element is visible    ${dropDownMenu}
    Click Element    ${dropDownMenu}
    Click Element    ${ManageWebsiteTab}
    Element Should Be Visible    ${ManageEventOption}



