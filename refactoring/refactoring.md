# Refactoring

## Characterization Tests

If not unit tests, write tests that reflect the current behaviour of the system:

Theis technique involbes writing a test, knowing the assertion will fail. When it fails, look at the actual result of the test. Rewrite the assertion to assert the correct result = test has captured (at least one aspect) of the current behaviour, which will support our refactoring.

## Toward cleaner code

Remove Duplication
Improve naming
Break up large code elements
Reduce coupling (unless they are likely to change together)
Reduce Complexity
Split Responsibility

Principle of Least Astonishment.

Code smell "types"

Bloaters: code growth, becoming do-it-all classes
Object-Orientation abusers: disrupt value of OO. Break polymorphism
Change preventers: touch many parts of the system, tight coupling, poor separation of concerns.
Dispensables: provide little or no value, can be removed with little effort. might be commented out.
Couplers: tie unrelated parts together.
Obfuscators: hide intent

### c sharp

#### statement smells

##### Primitive Obsession

overuse of primitives, instead of better abstractions or data structures. results in excess code required to enforce constraints = Bloater.

`AddHoliday(7,4);` // 7th april, june 4th ?

```c#
var independenceDay = new Date(month: 7, day: 4); //named args help clarify day/month confusion.
AddHoliday(independenceDay); //named variable helps

//or even replace primtive with Enum or class
AddHoliday(Constants.Month.July, Constants.Day.Day_4);
```

##### Vertical Separation

Define, assign and use variables and function near where they are used.

Define local variables where first used, ideally as they are assigned.

Define private functions just below their first use. Avoid forcing the reader to scroll.

##### Inconsistency

Be consistent.

#### Poor Names

Avoid abbreviations and encodings.

Descriptive, Appropriate level of abstraction (domin var should not use db terms). Follow standards; Unambiuous, Longer names for longer scopes (short scopes may have short names, sb, i etc)

Avoid Encodings: strName etc

##### Switch Statements

and complex if-else chains may indicate a lack of proper use of OO design == OO Abuser.

One switch is fine, but if the same switch is used repeatedly (if tenant_A elseif tenant_ B etc). Violates DRY and lack of encapsulation. Instead use polymorphism.

##### Duplicate Code - the root of all software evil

Copy-Paste code.

Instantiation (if ctor changes, need to update all instances)

Verbose guard clauses.

##### Dead Code (not executed)

extra using statements, unused local variables, unreachable code etc

##### Hidden Temporal Coupling

Certain operations must be called in a certain sequence or they won't work. Nothing in the design forces this behaviour, developers just have to figure it out. Can often be fixed using the Template Method design pattern.

#### method smells

##### Long Method

Should not be larger than your head / no scrolling.

Extract Method. Componse Method (high level method deleages to lots of smaller methods). Replace nested conditional with guards.

Replace Conditional Dispatcher with Command...investigate

Move Accumulation to Visitor...investigate

Replace Conditional Logic with Strategy...investigate

##### Conditional Complexity

The number of unique logical paths through a method can be measured as Cyclomatic Complexity - which should be kept under 10.

See VS Code Metrics.

##### Inconsistent Abstraction Level

Methods should operate at a consistent abstraction level - Don't mix high level and low level behaviour in the same method eg: A UI component should just deal with UI stuff.

##### Method Refactorings

ExtactMethod, RenameMethod, InlineMethod (opposite of extract)

Introduce Explaining Variable - use a temporary variable to help explain some part of some complex logic `coneArea * height /3;`

InlineTemp - replace the var with the actual logic

Replace Temp with Query

Split Temporary Variable - reused, long lived temps are a common source of bugs

Parameterize method - merge methods that share logic

Separate Query from Modifier - split out the query (no side affects) from the bit that has a side effect.

Rule?: Mothods that return a value should not have side-affects

#### class smells

Large Class - violates SRP. Break it up: Extract Method, Extract Class, Extract Subclass or Interface

Replace Conidtional Dispatcher with Command... investigate

Small or Anemic class / Lazy class - inline class

Temporary Field - Class has fields that are only set in certain conditions. How to know when to use method that relies on the field? Can fix in many ways, eg ExtractClass

Data Class - Class is just a DTO. Problem is the things that use this class have the logic. So move the logic to the class itself, or use injected Strategy classes

Feature Envy: one object is overly interesed in another objects state. Coupler smell.

Hidden dependencies - external deps not specified through constructors. Also calls to non-stateless static methods.
