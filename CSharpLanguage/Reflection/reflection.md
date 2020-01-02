# Practical Reflection

Assembly - one or more modules, the main module contains an Assembly manifest (name, version, culture, module list). Module Metadata describes all types, methods, fields, ctors etc, including IL (the runnable code)). Resources may also contains Resources (textfiles, images etc). Assemblies are self describing.

see ILDASM to see into an Assembly.


Reflection - inspecting the metadata and compiled code in an assembly.

quick examples using reflection:
```
Type listType = typeof(List<int>);
var list = Activator.CreateInstance(listType); //same as var list = new List<int>();

var list = new List<int>();
Type listType = typeof(List<int>);
Type[] parameterTypes = { typeof(int) };
MethodInfo mi = listType.GetMethod("Add", parameterTypes);
mi.Invoke(list, new object[] { 23 }); //same as  list.Add(23);
```

### Practical Reflection Strategy

+ Dynamically Load Assemblies - Happens one time (at start up) 
+ Dynamically Load Types - Happens one time (at start up) 
+ Cast Types to a Known Interface 
    + All method calls go through the interface
    + No dynamic method calls –no MethodInfo.Invoke  
    + Avoid interacting with private members

## Dynamic loading with configuration

eg: Factory using relection to return an abstraction (interface). Dynamic loading of required assemblies via `public static Type GetType(string typeName)` or `Type type = typeof(CSVRepository)`. The first option is useful when we don't have a reference to the type in our code.

Given a Type, we can use the Activator Class to create an instance of the type

`public static object CreateInstance(Type type)`

Example Assembly-Qualified Type Name:

```
System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, 
EntityFramework, 
Version=5.0.0.0, 
Culture=neutral, 
PublicKeyToken=b77a5c561934e089
```

= FQN, AssemblyName, Assembly Version, Culture, Token

```
public static IPersonRepository GetPersonRepository()
{
    string repoTypeName = ConfigurationManager.AppSettings["RepositoryType"]; // get AQN from the config file
    Type repoType = Type.GetType(repoTypeName);
    object repoInstance = Activator.CreateInstance(repoType);
    IPersonRepository repo = repoInstance as IPersonRepository;
    return repo;
}
```
The example above uses reflection to create instance each time. This really should only happen once if possible.

note: .NET will look for the assembly in the GAC and the same location as the .exe


@demo dynamic loading