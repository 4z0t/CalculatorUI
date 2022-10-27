Feature: Calculator
	Simple calculator for adding two numbers

@positive
Scenario: Add two numbers
	Given Calculator is initialized
	When I type number 3.0
	And I press Plus
	And I type number 4.0
	Then the result should be 7.0 on the screen