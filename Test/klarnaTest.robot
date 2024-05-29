*** Settings ***
Library     SeleniumLibrary
Library     DateTime
Library     Collections
Resource    masterResourceFile.robot
Suite Setup    Open Chrome browser

*** Test Cases ***
fTest - If i can Buy With Klarna
   Given I Chose To Pay With Klarna
   Then Klarna Is Showing

