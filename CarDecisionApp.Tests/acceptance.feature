Feature: Filter high-performance cars
  As a user
  I want to filter cars based on horsepower
  So that I can see only high-performance cars

  Scenario: Filter cars with horsepower above 150
    Given a list of cars
    When I filter the list with a minimum horsepower of 150
    Then I should see only cars with horsepower above 150
