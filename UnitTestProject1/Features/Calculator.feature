Feature: Calculator
	Simple calculator for adding two numbers

@positive
Scenario: Do number action
	Given Calculator is initialized
	When I type number <firstValue>
	And I press <action>
	And I type number <secondValue>
	Then the result should be <result> on the screen

Examples: 
| firstValue | secondValue | action   | result |
| 2.5        | 3.6         | Plus     | 6.1    |
| 2.5        | 3           | Multiply | 7.5    |
| 1          | 2           | Plus     | 3      |
| 2          | 3           | Minus    | -1     |
| 2          | 2           | Multiply | 4      |
| 2          | 2           | Divide   | 1      |