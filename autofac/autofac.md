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



