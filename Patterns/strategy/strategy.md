# Strategy pattern

Characteristics:

+ Context - Has a reference to it (the strategy)
+ IStrategy - Defines the interface for the given straregy
+ Strategy - concrete implementation

A common and simple pattern. eg:

Context calls `IStrategy.GetTaxFor(order)`

IStrategy defines the contract.

Strategy implementations, eg: UkSalesTaxStrategy, UsaSalesTaxStrategy...

or IStrategy.CreateInvoice() has strategies PdfInvoiceStrategy, EmailInvoiceStrategy, PrintInvoiceStrategy...

Select an implementation at runtime based on user input without having to extend the class.

Can inject the strategy into the class or a method.