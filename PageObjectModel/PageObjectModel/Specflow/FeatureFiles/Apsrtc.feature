Feature: APSRTC Basic Flows	

@Book
Scenario: Book Ticket
	Given I Launch Apsrtc website
	When  I Logged in to the website
	When I Book Ticket by giving journey details
	Then I Could see the list of buses available

@Book
Scenario: Book Ticket with Data
	Given I Launch Apsrtc website "https://www.apsrtconline.in/"
	When  I Logged in to the website
	When I Book Ticket from "GUNTUR" to "TIRUPATHI" 
	And I gave date of journey as "1" and return journey as "5"
	Then I Could see the list of buses available
@Book
Scenario Outline: Book Ticket with table data
	Given I Launch Apsrtc website
	When  I Logged in to the website
	When I Book Ticket by giving journey details
	Then I Could see the list of buses available
Examples: 
|          URL						| FromCity   | ToCity      | DataofJourney | ReturnJourney |
| https://www.apsrtconline.in/      | GUNTUR     | VIJAYAWADA  | 1             | 6             |
|https://www.apsrtconline.in/		| TIRUPATHI	 | VIJAYAWADA  | 1             | 6             |
| https://www.apsrtconline.in/      | GUNTUR     | VIJAYAWADA  | 5             | 6             |
|https://www.apsrtconline.in/		| TIRUPATHI	 | VIJAYAWADA  | 8             | 16            |

@Book
Scenario: Book and Check Ticket Status
	Given I Launch Apsrtc website
	When  I Logged in to the website
	When I Book Ticket by giving journey details
	Then I Could see the list of buses available
	When I Navigate to Ticket Status
	And I gave the ticket number and search
	Then I could see the ticket status
@Book
Scenario: Book and Cancel Ticket
	Given I Launch Apsrtc website
	When  I Logged in to the website
	When I Book Ticket by giving journey details
	Then I Could see the list of buses available
	When I Navigate to Cancel
	And I Cancel the ticket
	Then I could see the ticket got cancelled