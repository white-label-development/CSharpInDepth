## AutoFac

via NuGet: Autofac + Autofac.Mvc5 + Autofac.WebApi2

Standard setup in Global.asax.cs

```
var builder = new ContainerBuilder(); //part 1 of AF's two step process

// builder.RegisterType<HomeController>();  //manual registration

builder.RegisterControllers(typeof(MvcApplication).Assembly); // register everything (all MVC controllers) in the named assembly automatically.

builder.RegisterApiControllers(typeof(MvcApplication).Assembly); //and the web apis

IContainer container = builder.Build(); //part 2

//replace default .net resolver (which just instantiates the controller (but not it's deps)) with autofac

DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); // set resolver and cache it between requests (so it's always available). This is for Mvc Controllers, not webapi

GlobalConfiguaraion.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);  //web api
```

OWIN based hosting is pretty much the same, except uses Startup.

### Component Lifetime

Transient: lifetime of injected instance equal to the lifetime of what it was injected in to. ie: as long as the controller, similar to new-ing it in the controller BUT might not be GC's for a long time if the framework is not sure that everthing is done.

Singleton: lives as long as the container

Scoped: not equated to anything and handled through manual means.

eg: change registration to

```
builder.RegisterApiControllers(typeof(MvcApplication).Assembly).InstancePerRequest(); 
// "manually" decide the lifetime of these objects.
```

### Assembly Scanning, Autofac Modules, Configuration Files:

`RegisterType<T>().As<U>(); // procedural reg`

```
RegisterControllers(); // assembly scanning
RegisterApiControllers();
```

With Modules, component registration are offloaded to a separate class. Can be logically grouped together.

Configuration files may also be used. XML or JSON. Individual or module-based.


Assembly Scan & Register:

Convention: Interface is named the same as the class, but with an 'I' prefix.

Scan can be restricted using lambdas and so on.

Can put registration in a separate class, them register the class eg: `builder.RegisterModule<MyRepoRegModule>();`

Can use AutoFac Configuration Nuget package to have json/xml configuration file. (i don't like the look of these).



### Injecting and Resolving

Scenario: 5 action methods, each needs a diferenr dependency injected - but only 1 of the 5 will be used in any request. 
It's a waste of resources to instantiate them all - can't we just new the one we need without resorting to method injection?...

Use of "creation component" to resolve other components - based on abstract factory / service locator

```
    public class ComponentLocator : IComponentLocator
    {
        public ComponentLocator(ILifetimeScope container)  {  _Container = container; }

        ILifetimeScope _Container;

        T IComponentLocator.ResolveComponent<T>() {  return _Container.Resolve<T>();  }
    }

    public interface IComponentLocator  { T ResolveComponent<T>(); }

```

IComponentLocator is first registered with AF, then injected into ctor, amd used within methods

```
 IBlogPostRepository blogPostRepository = _ComponentLocator.ResolveComponent<IBlogPostRepository>();
```

In a view we can also access the built in MVC.DependencyResolver which has autofac registered to it as tje current implementation.
```
 var localStrings = DependencyResolver.Current.GetService<EasyBlog.Web.Core.ILocalStrings>();
```

### Advanced Patterns

Decorators in this context is a pattern we can use to DI constructs we don't control. eg: Configuration Manager, Activator methods (static classes) etc.

Solution is to wrap or factory what we need, abstract to an Interface, register and inject.

Also covered:

MVC and API attributes, with property injection ... .PropertiesAutowired() .... 


### Additional Scenarios

owi, etc.

DONE
-------------------------------------






