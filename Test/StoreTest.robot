*** Settings ***
Library     SeleniumLibrary
Library     DateTime
Library     Collections
Resource    masterResourceFile.robot
Suite Setup    SetUp with Admin Login


*** Test Cases ***

Test - Adding A Product To Shopping Cart
    
    Given I am at the store
    When I click on a product product
    Then I should be directed to game detail page
    When I click buy procuct
    And I should be redirected to Checkout page

Test - As An Admin I Can Add A Game
    [Documentation]
    Set Selenium Speed    0.3
    When I Go To The Game Manager
    And I Add A Game
    Then The Game Is In The Store

Test - As An Admin I Can Change A Game
    [Documentation]
    Set Selenium Speed    0.3
    When I Go To The Game Manager
    And I Change A game
    Then The Game Is Changed

Test - As An Admin I Can Remove A Game
    When I Go To The Game Manager
    And I Remove A game
    Then The Game Is Removed

