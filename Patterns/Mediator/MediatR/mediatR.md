## MediatR

Conceptually more like an in-memory messaging system. Both Send/Recieve style and broadcast command style messages.

Often used with vertical slices style architecture

_Connects request handlers with the appropriate request and response objects_


#### Notes on the demo

Nuget MediatR, the MediatR DI extension, the MS .EntityFramewrok.InMemory db (so we don't need to bother with a real db for the demo)

See `IRequestHandler`

Demo is too basic (focus was on the Mediator pattern, not MediatR). Look for something else.

Pattern takeaway: "When you think of the mediator pattern, you should think of encapsulating object interaction between multiple _colleague_ objects, and doing this with loose coupling so the colleague objects don't all have to know about each other."