*** Settings ***
Library     SeleniumLibrary
Library     DateTime
Library     Collections
Resource    masterResourceFile.robot

*** Keywords ***

Given that I Click the Customer Basket
    Click Element   //*[@id="kundkorgsButton"]/i
Then I Am At Customer Basket Page
    Page Should Contain Element    //*[@id="offcanvas"]/div[2]/div/div[2]/button