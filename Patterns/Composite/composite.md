## Composite Pattern

Think: Tree Structures (data structures with parent/child relationships)

Composite objects into tree structures

Uniform interaction
 + Leaf: No children
 + Composite: Has Children


The pattern allows us to manipulate component at any level of tree hierarchy  
  
Component _I am a common interface. Including the primary operation (eg: GetSizeInBytes()) _

Composite _I am a component with children. Inherits from Component. Maintains list of children_

Leaf _I am a component without children. Inherits from Component._

Client _I manipulate objects in the composition. Invokes the primary operation_

#### File System example

root - directories - directories contain other directories and files - files

Consider a file system. Folders are a Composite and Files are a Leaf. The composite pattern is not only about modeling tree structures, but in particular, enabling clients to act on those tree structures uniformly. 

For example, if I want to get the size of an individual file, then I could have a method on this individual File #7 here to give me its size, and it returns me the number of bytes in the file. But what if I wanted the size of a directory, say Directory 4? I want to just call a method on Directory 4 here, and as a consumer, I don't want to have to worry about the details of the work of going through all the directory's files to add up all their sizes so I can get the total size of the directory. 

Or, what if I wanted the size of Directory 2? I just want a simple method to call on Directory 2 without worrying about the details. 

So conceptually, this is what the composite pattern is enabling, whether I want to act upon the granular level of an individual leaf node, a file in this case, or if I want to act upon the entire structure or I want to act upon just a subsection like one of the directories. The composite pattern will enable us to deal with all this uniformly. 

A composite pattern commonly consists of these four items, a component, the composite, a leaf, and the client.

#### Notes

See FileSystemBuilder in demo for an example of using the builder pattern to encapsulate file/directory creation. Also note the neat `SetCurrentDirectory()` function and the way it traverses the tree.
