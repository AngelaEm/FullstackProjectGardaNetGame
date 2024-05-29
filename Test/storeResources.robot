*** Settings ***
Library     SeleniumLibrary
Library     DateTime
Library     Collections
Resource    masterResourceFile.robot
#Test Teardown   Run Keywords


*** Keywords ***

I am at the store
    Sleep    1
    When I click the Store
    Wait Until Page Contains Element    ${GamePageTitle}


I click on a product product
    Sleep    1
    Wait Until Page Contains Element    ${gameOne}
    Click Element    ${gameOne}

I should be directed to game detail page
    Sleep    1
    Wait Until Page Contains Element    ${BuyButton}    timeout=10

I click buy procuct
    Sleep    1
    Wait Until Page Contains Element    ${BuyButton}
    Click Element    ${BuyButton}

I should be redirected to Checkout page
    Sleep    1
    Wait Until Page Contains Element    ${KlarnaButton}


When I Go To The Game Manager
    Sleep    1
    Wait Until Element Is Visible    ${dropDownMenu}
    Click Element    ${dropDownMenu}
    Element Should Be Visible    ${ManageWebsiteTab}
    Click Element    ${ManageWebsiteTab}
    Sleep    1
    Scroll Element Into View    ${ManageGameOption}
    Wait Until Element Is Visible   ${ManageGameOption}
    Click Element    ${ManageGameOption}
    Wait Until Element Is Visible   ${SelectGameForm}

And I Add A Game
    Input Text  ${GameTitleForm}    ${GameTitle}
    Select From List By Label    ${SelectGenreForm}    ${selectGenre}
    Input Text    ${ReleaseDateForm}    ${releaseDate}
    Input Text    ${StudioForm}    ${studio}
    Input Text    ${PublisherForm}    ${publisher}
    Input Text    ${GameDescriptionForm}    ${gameDescription}
    Input Text    ${AgeRestrictionForm}    ${ageRestriction}
    Choose File    css=.form-control[type="file"]    ${CURDIR}/1814630-box_ff7.png
    Input Text    ${MultiplayerForm}    ${Multiplayer}
    Input Text    ${GamePriceForm}    ${GamePrice}
    Input Text    ${PlatformForm}    ${Platform}
    Input Text    ${VideoForm}    ${Video}
    Input Text    ${SystemRequirementForm}    ${SystemRequirement}
    Input Text    ${OnlineFunctionalityForm}    ${OnlineFunctionality}
    Scroll Element Into View    ${GameSubmitButton}
    Wait Until Element Is Visible    ${GameSubmitButton}
    Click Element    ${GameSubmitButton}

Then The Game Is In The Store
    Sleep    2
    Scroll Element Into View    ${storeTab}
    Click Element    ${storeTab}
    Game is visible in store    ${GameTitle}

And I Change A game
    Sleep    1
    Select From List By Label    ${SelectGameForm}  ${gameTitle}
    Select From List By Label    ${SelectGenreForm}    ${selectGenre}
    Input Text    ${GameTitleForm}    ${GameNameChange}
    Scroll Element Into View    ${GameSubmitButton}
    Click Element    ${GameSubmitButton}

Then The Game Is Changed
    Sleep    2
    Scroll Element Into View    ${storeTab}
    Click Element    ${storeTab}
    Game is visible in store    ${GameNameChange}

And I Remove A game
    Sleep    1
    Select From List By Label    ${SelectGameForm}    ${GameNameChange}
    Scroll Element Into View    ${GameDeleteButton}
    Click Element    ${GameDeleteButton}

Then The Game Is Removed
    Sleep    2
    Scroll Element Into View    ${storeTab}
    Click Element    ${storeTab}
    The game is no longer visible in store    ${GameNameChange}


Create List of Games
    [Documentation]     
    @{gameList}     Create List
        FOR    ${IndexNumber}    IN RANGE    1    100
            ${elementIsPresent}=    Run Keyword And Return Status    Element Should Be Visible    //div[@id='card.${IndexNumber}']
            IF    ${elementIsPresent} == True
                @{CardTitles}       Get WebElements     //h5[@id='cardtitle.${IndexNumber}']
                    FOR    ${CardTitle}    IN    @{CardTitles}
                        ${TitleOfGame}     Get Text    ${CardTitle}
                        Append To List     ${gameList}       ${TitleOfGame}
                    END
            ELSE
                BREAK
            END
        END
    RETURN      ${gameList}



Game is visible in store
    [Documentation]     verifies newly added game to store as a card
    [Arguments]    ${expectedValue}
    @{ProductTitles}    Create List of Games
    List Should Contain Value    ${ProductTitles}    ${expectedValue}


The game is no longer visible in store
    [Arguments]    ${expectedValue}
    Wait Until Element Is Visible    ${storeTab}
    Click Element    ${storeTab}
    @{ProductTitles}    Create List of Games
    List Should not Contain Value    ${ProductTitles}    ${expectedValue}