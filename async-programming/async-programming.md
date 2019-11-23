# Asynchronous programming in .NET

## Basic async await stuff

`WebClient` = sync _vs_ `HttpClient` = async

| Traditional                                        | Current   | 
| -------------:                                      |:-------------| 
| Threading (low-level)                              | Task parallel library | 
| Background Worker (Event-based async pattern)      | Async and await      | 



async without await is still synchronous.

await: Gives you a potential result; validates the success of the operation; Continuation is back on calling thread.

(client in the example below is HttpClient)

```
var response = client.GetAsync('some url'); //note the missing await
var myData = response.Result(); //noob error: Calling result or wait will BLOCK (until available) and potentially DEADLOCK the app.
```

always use await on async methods
```
var response = await client.GetAsync('some url');
var content = await response.Content.ReadAsStringAsync(); // this read is async so needs an await too
```

Suffixing async methods with the async is no longer an offical design guideline. Yay! I hated that.


await also introduces 'continuation' in that in our `var response = await client.GetAsync('some url');` example, the code after that gets placed in a contination 'box' to be completed after the async operation has completed.
Each await cretes it's own continuation, allowing us to get back to the original thread.


Tip: Don't do `async void` (except for event handlers or delegate). Use `async Task`. Also, exceptions occuring in an async void method cannot be caught (even with a try/catch).

Handling Exceptions:

As normal as long as async + await is used. Async all the way.

Best Practices:

avoid `.Result()` (without await) and `.Wait()`.

## Using the Task Parallel Library









