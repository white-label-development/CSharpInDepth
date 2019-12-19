## BDD 1 - DISCOVERY

Every test is an *example*. Every example is an expression of a required system behaviour.

With sufficient examples you define the behaviour of the system = you have documented the requirements.

Examples are often
    Given, When, Then, (And) ==> a scenario

Scenario: Allow address change while the order is in preparation
Given: The client's order is in preperation.
When: The client changes the delivery address
Then: The change should be accepted
And: The new address should become the delivery address.

BDD => collect and discuss examples (while working with a user story).

Examples describe behaviour as a combination of context, action and outcome.


### Structured Conversation

Structured Conversations [with people] are collaborative, diverse perspectives, short (max 30 mins), show progressive focus, find consensus.

Requirement Workshop: used to explore a story, it's scope, and illustrate it unambiguously with example (example mapping).

In our example, the story begins as **Change Delivery Address**.

SideNote: gently build user personas to help identify potential behaviours. The Peter persona is a user who orders pizzas
from home and the office, so is ideal as a "whoops can I change the delivery address" person.

The happy path: Customer is allowed to change the delivery address.

The first Example Card (green):
Order is in preparation
* Peter orders a pizza for home address
* Order processing has begun but pizza is not ready
* Chooses "change address"
* Selects work address
* Submits change
=> Change accepted.

In the book, the example card is discussed by team who notice that the state of the pizza is described as both
"in preparation" and "not ready". Leads to discussion exploring state and realization that Peter can actually change
the address up till "Picked up" state. Result of this chat: Example card title changed to "Order waiting for pickup"
, and "...order procssing..pizza not ready" changed to "Pizza waiting for Pickup".

The first Example Card illustrates a new rule (blue card): "Allow address change if not picked up yet".


Attention! (I got this the wrong way round at first. might become clearer later...)

For a single story we are mapping on a wall with post-its:
* lvl1: one story
* lvl2: rules
* lvl3: under each rule, ExampleCards.

More examples follow the discussion:
* Example Card: "Order picked up already" (the sad path)
* Example Card: "Order picked up during address change process"

which spawn more rules
* "only valid address is accepted"
* "ETA is updated"
* "new address must be in delivery range"
* etc.


##### Example Mapping

Important: Cards should not contain technical implementation details.

*Examples (green)* - illustrate concrete behaviour (of valid entry and invald entry)

*Rules (blue)* - eg: "only valid address accepted"

*Question or Assumption (red)* - so conversation blockers are visible and not rediscussed endlessly

*User stories (yellow)*

![example](https://miro.medium.com/max/700/1*BrGJ6H_TdbHu0-ik0Y7vNg.png)


Suggests use "Friends" naming for examples, eg: "The one where... the Order has not been picked up yet"



### What is an Example?

Think of an example as a 3 part artifact of CONTEXT, ACTION, OUTCOME (...but think of these in reverse order)

Outcome: describes the state of the system after the behaviour we're exploring has taken place
Action: the event that causes the behaviour
Context: the "initial" state of the system before the action.

Tip: Try to create example that illustrate a single rule.




### Who does what and when

1. Pick a User Story - scoped with relevant business rules. Enough detail to allow dev team to create examples.
2. Requirement Worskhop - focus on rules and examples for the story. DO NOT use Given/When/Then at this point.
3. Formulate - examples -> scenarios
4. Review - review the scenarios for correctness
5. Automate - Automate the scenarios by writing test automation code. Do this before starting implementation (TDD)
6. Implement - Produces a working feature that behaves as specified and verified automatically


### Misc

In scrum, the best approach to formulating scenarios is to include it as a task eg: "Formaulte the examples of story (x) as scenarios 
and add them to source control."


