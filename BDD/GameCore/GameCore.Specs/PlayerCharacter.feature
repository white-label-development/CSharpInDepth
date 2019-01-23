Feature: PlayerCharacter
	In order to play the game
	As a human player
	I want my character attributes to be correctly represented

# Given I'm a new player is repeated, so we can use a Background
Background: 
	Given I'm a new player


Scenario Outline: Health reduction
	#Given I'm a new player
	When I take <damage> damage
	Then My health should now be <expectedHealth>

	Examples: 
	| damage | expectedHealth |
	| 0      | 100            |
	| 40     | 60             |

#Scenario: Taking no damage when hit does not affect health
#	Given I'm a new player	
#	When I take 0 damage
#	Then My health should now be 100
#
#Scenario: Starting health is reduced when hit
#	Given I'm a new player
#	When  I take 40 damage
#	Then My health should now be 60

Scenario:Taking too much damage results in player death
	#Given I'm a new player
	When I take 100 damage
	Then I should be dead

Scenario:Elf race characters get additional 20 damage resistance
	#Given I'm a new player
	And I have a damage resistance of 10
	And I'm an Elf
	When I take 40 damage
	Then My health should now be 90

Scenario:Elf race characters get additional 20 damage resistance using data table
	#Given I'm a new player
	And I have the following attributes
	| attribute | value |
	| Race | Elf |
	| Resistance | 10 |	
	When I take 40 damage
	Then My health should now be 90

Scenario: Healers restore all health
	Given My character class is set to Healer
	When I take 40 damage
		And Cast a healing spell
	Then My health should now be 100








