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

The logic improvement here is generics:

```
public static T Get<T>() where T : class
{
    string requestedType = typeof(T).ToString(); // requestedType == the appSettings key
    string resolvedTypeName = ConfigurationManager.AppSettings[requestedType]; //get appSettings key value = is type AQN eg: "GenericRepository.CSV.PersonRepository, GenericRepository.CSV, Version=1.0.0.0, Culture=neutral"
    Type resolvedType = Type.GetType(resolvedTypeName); // string to resolved type
    object instance = Activator.CreateInstance(resolvedType); // type to instance
    T result = instance as T;
    return result;
}
```


## Discovering Types in Assemblies

example scenario: order taker - looks in a /rules/ folder for .dll that contains the order rules. The idea being we don't have to modify code in OrderTaker, instead we load in what changes (the customer specific rules).


```
 public static class DynamicOrderRuleLoader
{
    public static List<DynamicOrderRule> LoadRules(string assemblyPath)
    {
        var rules = new List<DynamicOrderRule>();

        if (!Directory.Exists(assemblyPath)) return rules;

        IEnumerable<string> assemblyFiles = Directory.EnumerateFiles(assemblyPath, "*.dll", SearchOption.TopDirectoryOnly); // get files

        foreach (string assemblyFile in assemblyFiles)
        {
            Assembly assembly = Assembly.LoadFrom(assemblyFile); // load assembly from the file system
            foreach (Type type in assembly.ExportedTypes)
            {
                // look for classes that implement IOrderRule
                if (type.IsClass && typeof(IOrderRule).IsAssignableFrom(type))
                {
                    IOrderRule rule = Activator.CreateInstance(type) as IOrderRule;
                    rules.Add(new DynamicOrderRule(
                        rule,
                        type.FullName,
                        type.Assembly.GetName().Name));
                }
            }
        }

        return rules;
    }
}
```



@???