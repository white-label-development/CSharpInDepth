# AutoMapper 

https://docs.automapper.org/


## Overview

```
var config = new MapperConfiguration(cfg => {
 cfg.CreateMap<Order, OrderDto>();
 cfg.AddProfile<FooProfile>();
});
```

You only need one MapperConfiguration instance typically per AppDomain and should be instantiated during startup. The MapperConfiguration instance can be stored statically, in a static field or in a dependency injection container. Once created it cannot be changed/modified.

To perform a mapping, call one of the Map overloads:
```
var mapper = config.CreateMapper();
// or
var mapper = new Mapper(config);
OrderDto dto = mapper.Map<OrderDto>(order);
```

Most applications can use dependency injection to inject the created IMapper instance.

https://docs.automapper.org/en/stable/Dependency-injection.html#asp-net-core


## Configuration

Profiles are classes that inherit from Profile. Configuation goes in the ctor. 

Profiles can be added directly with `.AddProfile` or using assembly scanning.

Can set naming conventions in MapperConfiguration (or per profile ofc). I think default is `ExactMatchNamingConvention`

`configuration.AssertConfigurationIsValid();`

ignore using `cfg.CreateMap<Source, Destination>()
	.ForMember(dest => dest.SomeValuefff, opt => opt.Ignore())`

## Projection, Flattening etc

When you want to project source values into a destination that does not exactly match the source structure, you must specify custom member mapping definitions.

Flattening...Nested mappings...Lists and Arrays (can map collections eg: ` mapper.Map<Source[], IEnumerable<Destination>>(sources)`)...Child Mappings (inheritance, ploymorphism)

Flattens GetTotal() function into Total property.

`.ReverseMap();` can unflatten. Use `ForPath` to customize.


## Queryable Extensions

hmn caution n+1 issues.











