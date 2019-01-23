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

# demonstrates step argument conversion of "Healer" to CharacterClass enum type.
Scenario: Healers restore all health
	Given My character class is set to Healer
	When I take 40 damage
		And Cast a healing spell
	Then My health should now be 100



# multi column step table data
Scenario: Total magical power
Given I have the following magical items
| name   | value | power |
| Ring   | 200   | 100   |
| Amulet | 400   | 200   |
| Gloves | 100   | 400   |
Then My total magical power should be 700



Scenario: Reading a restore health scroll when over tired has no effect
	Given I last slept 3 days ago
	When I take 40 damage
		And I read a restore health scroll
	Then My health should now be 60

Scenario: Reading a restore health scroll when rested has a full effect
	Given I last slept 1 days ago
	When I take 40 damage
		And I read a restore health scroll
	Then My health should now be 100

Scenario: Weapons are worth money
Given I have the following weapons
|name|value|
|Sword|50|
|Pick|40|
|Knife|10|
Then My weapons should be worth 100

