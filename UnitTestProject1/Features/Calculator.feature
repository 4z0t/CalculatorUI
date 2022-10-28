Feature: Calculator
	Calculator

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
| 2.5        | 3           | Minus    | -0.5   |
| 2.5        | 3           | Multiply | 7.5    |
| 2.5        | 2           | Divide   | 1.25   |
| 1          | 2           | Plus     | 3      |
| 2          | 3           | Minus    | -1     |
| 2          | 2           | Multiply | 4      |
| 2          | 2           | Divide   | 1      |


@negative
Scenario: Wrong input
	Given Calculator is initialized
	When I type number <firstValue>
	And I press <action>
	Then the error is on screen
	
Examples: 
| firstValue | action   |
| 2.5        | Plus     |
| 2.5        | Minus    |
| 2.5        | Multiply |
| 2.5        | Divide   |
| 1          | Plus     |
| 2          | Minus    |
| 2          | Multiply |
| 2          | Divide   |

@negative 
Scenario: Zero division
	Given Calculator is initialized
	When I type number <number>
	And I press Divide
	And I type number 0
	Then the error is on screen

	Examples: 
| number	 | 
| 2.5        | 
| 0	         | 
| 0.7        | 
| 0.5        | 
| 1          |  
| -2         | 
| 2          | 
