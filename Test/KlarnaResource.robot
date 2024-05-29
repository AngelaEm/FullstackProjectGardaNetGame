*** Settings ***
Library     SeleniumLibrary
Library     DateTime
Library     Collections
Resource    masterResourceFile.robot

*** Keywords ***

Given I Chose To Pay With Klarna
    Sleep    1
    Click Element   //*[@id="kundkorgsButton"]/i
    Click Element    css:button.btn.btn-warning
    click element   css:button.btn-close
    Click Element    css:button.btn.btn-warning.mt-2

Then Klarna Is Showing
    Page Should Contain Element    //*[@id="klarna-checkout-container"]