*** Settings ***
Documentation   resource file for event page
Library     SeleniumLibrary
Library     Collections
Library     OperatingSystem
Library    XML


Resource    masterResourceFile.robot


*** Keywords ***

I am at the event overview
    [Documentation]
    [Tags]
    Sleep    1
    Wait Until Page Contains Element    ${eventTab}
    Click Element    ${eventTab}
    Wait Until Page Contains Element    ${NewestEventSeeMoreButton}

I am at the event manager
    [Documentation]
    [Tags]
    Sleep    1
    Scroll Element Into View    ${dropDownMenu}
    Click Element    ${dropDownMenu}
    Wait Until Page Contains Element    ${ManageWebsiteTab}
    Click Element    ${ManageWebsiteTab}
    Wait Until Page Contains Element       ${ManageEventOption}     timeout=10


I add a new event
    Sleep    2
    Wait Until Page Contains Element    ${eventNameForm}
    Wait Until Element Is Visible    ${eventTypeForm}
    Select From List by Value    ${eventTypeForm}    ${eventType}
    Input Text    ${eventNameForm}    ${eventName}
    Input Text    ${eventDateForm}    ${eventDate}
    Input Text    ${eventLocationForm}    ${eventLocation}
    Click Element    ${eventIsUpcoming}
    Input Text    ${eventDescriptionForm}    ${eventDescription}
    Input Text    ${eventAgeRestrictionForm}    ${eventAgeRestriction}
    #Input Text    ${eventImageUrlForm}    ${eventImageUrl}
    #Input Text    ${eventBackgroundImageForm}    ${eventBackgroundImage}
    Input Text    ${eventDurationForm}    ${eventDuration}
    Input Text    ${eventCapacityFrom}    ${eventCapacity}
    Input Text    ${eventPriceForm}    ${eventPrice}
    Wait Until Element Is Enabled    ${submitEvent}  timeout=50
    Scroll Element Into View    ${submitEvent}
    Click Element    ${submitEvent}

The event is visible on event overview
    [Arguments]    ${expectedValue}

    Sleep    1
    Scroll Element Into View    ${eventTab}
    Wait Until Element Is Visible    ${eventTab}
    Click Element    ${eventTab}
    Sleep    3
    Event Is added to overview    ${expectedValue}


I change an existing event
    Wait Until Page Contains Element    ${EventChoiceForm}
    Select From List By Label    ${EventChoiceForm}     ${eventName}
    Input Text    ${eventNameForm}    ${changedEventName}
    Sleep    1
    Scroll Element Into View    ${submitEvent}
    Click element    ${submitEvent}

    

I remove an event
    Wait Until Page Contains Element    ${EventChoiceForm}
    Select From List By Label    ${EventChoiceForm}     ${changedEventName}
    Sleep    1
    Scroll Element Into View    ${deleteEvent}
    Click Element    ${deleteEvent}

The event is no longer visible on event overview
    [Arguments]    ${expectedValue}
    Wait Until Element Is Visible    ${eventTab}
    Click Element    ${eventTab}

    @{ActiveEventTitles}    Create List of Events
    List Should not Contain Value    ${ActiveEventTitles}    ${expectedValue}


I click on an event
    [Documentation]
    [Tags]
    Wait Until Element Is Visible    ${NewestEventSeeMoreButton}
    Click Element    ${NewestEventSeeMoreButton}

I am redirected to the event information page
    [Documentation]
    [Tags]

    Wait Until Element Is Visible    ${eventBuyButton}
    


When I count the events
    [Documentation]
    [Tags]
    ${actual_event_elements} =    Get WebElements    //p[starts-with(@id, 'cardd')]
    ${element_count} =    Get Length    ${actual_event_elements}
    Log    Found ${element_count} elements with ID starting with 'cardd'
    ${EXPECTED_EVENT_NUMBER} =    Set Variable    3  # Set expected number of events
    Convert To Integer    ${EXPECTED_EVENT_NUMBER}    # Ensure expected number is an integer
    Should Be Equal As Numbers    ${element_count}    ${EXPECTED_EVENT_NUMBER}
    # Log text of each element (optional)
    FOR    ${element}    IN    @{actual_event_elements}
        Log    ${element.text}
    END


Create List of Events
    [Documentation]     
    @{eventList}     Create List
        FOR    ${IndexNumber}    IN RANGE    1    100
            ${elementIsPresent}=    Run Keyword And Return Status    Element Should Be Visible    //div[@id='card.${IndexNumber}']
            IF    ${elementIsPresent} == True
                @{CardTitles}       Get WebElements     //h5[@id='cardtitle.${IndexNumber}']
                    FOR    ${CardTitle}    IN    @{CardTitles}
                        ${TitleOfEvent}     Get Text    ${CardTitle}
                        Append To List     ${eventList}       ${TitleOfEvent}
                    END
            ELSE
                BREAK
            END
        END
    RETURN      ${eventList}



Event is added to overview
    [Documentation]     verifies newly created event is added to eventoverview as a card
    [Arguments]    ${expectedValue}

    @{ActiveEventTitles}    Create List of Events
    List Should Contain Value    ${ActiveEventTitles}    ${expectedValue}
    

Then every active event from the DB should be visible
    [Documentation]
    [Tags]
    Element Should Be Visible    ${eventList}

Date,Time and Location should be visible on event overview
    [Documentation]
    [Tags]
    Page Should Contain    Kungsbacka
    Page Should Contain    03/25/2024 18:00:00

Then I can see the date, time and location
    [Documentation]
    [Tags]
    # TODO: implement keyword "i see the time and place".
    Fail    Not Implemented
        




I enter an invalid date
    Sleep    1
    Wait Until Element Is Visible    ${eventDateForm}
    Input Text    ${eventDateForm}    ${eventFalseDate}

Error message should be shown
    Sleep    1
    Page Should Contain    ${WrongDateFormatErrorMessage}

    