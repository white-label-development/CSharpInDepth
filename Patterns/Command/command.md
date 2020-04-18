## Command Pattern

The command pattern can easily be leveraged to allow undo or redo functionality.

Client *button*

Invoker *CommandManager*. 

Command *AddToCartCommand* A command contains all the data needed to process the request.

Receiver *ShoppingCart*


## Example: Shopping Cart Demo

(need to spend more time studying this one...)


Command Contains: 

The product which should be added to the cart

The Shopping Cart.

A way to check stock availability.


The CommandManager will keep track of both executing, checking if the command can be executed, as well as having a list or a stack of the commands that we have previously executed. A stack is ued so we can roll back in the correct order.


Note existing `System.Windows.Input.ICommand` in WPF project.