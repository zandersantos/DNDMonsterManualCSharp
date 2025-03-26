Feature: Monster Search
  Scenario: Searching for a monster
    Given I am on the home page
    When I click the search bar
    When I enter "Mimic" as the monster name
    When I click the search button
    Then I should be redirected to the monster detail page for "Mimic"