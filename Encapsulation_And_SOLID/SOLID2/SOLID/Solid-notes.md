### Revisiting SOLID code

Largely about dependency management.
also file:///C:/Users/neil/OneDrive/Work/books/solid-principles.pdf (book by EngineerSpock)

#### SRP

Single Responsibility Principles or SRP in short states that: every object should have a single responsibility, and that responsibility should be entirely encapsulated by the class.

eg:  if a class implements logging and caching on its own, then it has at least two responsibilities. 


##### axes of change

Given an API (or a class) consider it's users and that the users are the source of changes. 
If a class accesses a db, that's one ace since change requests can come from there.
If the class also deals with accounting reports, that's another axe.
The more responsibilities a class has, the more likely it’s going to be changed