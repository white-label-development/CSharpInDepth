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

If there is no async option in File, eg:
```
var lines = File.ReadAllLines('some file');
```

We can use the TPL to achieve what we get (for free) with async/await.

`Task` represents an async operation. Swallows exceptions.

`Task.Run()` queues the work passed as the action to run on a different thread by using the thread pool, and returns a `Task` that represents the ongoing work.


```
Task.Run(() => {
    var lines = File.ReadAllLines('some file'); // this is happening on a different thread.
    var data = new List<StockPrice>();
    // etc ...
    Stocks.ItemSource =  data; // will not work as we are on another thread. Stocks is on the 'UI' thread.
});

//do stuff with stock data
```

The above will not work as it all happen on some other thread. There will be no stock data after the Run(). The correct version:

```
await Task.Run(() => {
    var lines = File.ReadAllLines('some file'); // this is happening on a different thread.
    var data = new List<StockPrice>();
    // etc ...

    Dispatcher.Invoke(() => 
    {
        Stocks.ItemSource =  data;
    });     
});

//do stuff with stock data
```

Using 'await' we don't hit `//do stuff` until the file is read and the dispatcher thread has been updated with the result of the async operation.


```
var loadLinesTask = Task.Run(() => {
    var lines = File.ReadAllLines('some file'); 
    return lines;  
});

// ContinueWith creates a continuation (which is executed on a different thread) which runs async. This means it also returns a task.

loadLinesTask.ContinueWith(t => {
    var lines = t.Result() ... 
    //continue doing stuff within the continuation. Useful if chaining.
});

//Note: Calling the Result property on a task is OK as long as the task as finished the async part of the operation.

//now do stuff with stock data (in the example)
```

Continuattion when using ConfigureAwait will always execute by default after a task completed - even if there was an exception. eg:

```
var loadLinesTask = Task.Run(() => {
    var lines = File.ReadAllLines('some file THAT DOES NOT EXIST'); 
    return lines;  
});

var processStocksTask = loadLinesTask.ContinueWith(t => {
    var lines = t.Result() // BOOM as the file was not there 
});

processStocksTask.ContinueWith(_ => // nope because of ex in previous item in chain - but it will still be called!)
```

The `TaskContinuationOptions` exist to help control the default behaviours, eg: `.NotOnFaulted`, example:

```
var processStocksTask = loadLinesTask.ContinueWith(t => {
    var lines = t.Result() // BOOM as the file was not there 
}, TaskContinuationOptions.OnlyOnRanToCompletion); // will only run if PREVIOUS task (loadLinesTask) was ok.
```

Can create Continuation that only get called with there is a fault (such as to write a error message to the UI thread).


### Task Cancellation

CancellationTokenSource can produce a Token
`var loadTask = service.GetStockPricesFor(ticker, cancellationTokenSource.Token);`

and later in GetStockPricesFor()

`var result = await client.GetAsync($"http://localhost:61363/api/stocks/{ticker}",
                    cancellationToken);`


```
CancellationTokenSource cancellationTokenSource = null;
private void Search_Click(object sender, RoutedEventArgs e){

    // stuff

    if(cancellationTokenSource != null){
        cancellationTokenSource.Cancel();
        cancellationTokenSource = null;
        return; //if here, button to search has been clicked already, for SearchForStock() and the token set.
    }

    cancellationTokenSource = new CancellationTokenSource();
    cancellationTokenSource.Token.Register(() =>
    {
        Notes.Text += "Cancellation requested" + Environment.NewLine;
    });
    var loadLinesTask = SearchForStocks(cancellationTokenSource);
    
    //etc
    // in loadlineTask ...
    var processStocksTask = loadLinesTask.ContinueWith(t => { ... whatever }, TaskContinuationOptions.OnlyOnRanToCompletion);

}
```
Note: revisit this when actually using as there are some nuances.


### All or Any Completion

```
var service = new StockService();

var tickerLoadingTasks = new List<Task<IEnumerable<StockPrice>>>();
foreach (var ticker in tickers) //load them one at a time (but in parallel)
{
    var loadTask = service.GetStockPricesFor(ticker, cancellationTokenSource.Token);
    tickerLoadingTasks.Add(loadTask);
}


var allStocksLoadingTask = Task.WhenAll(tickerLoadingTasks); // all Tasks must be done

var completedTask = await Task.WhenAny(timeoutTask, allStocksLoadingTask); // first task(fastest), Returns a task, not the result as it's Task<Task>

if (completedTask == timeoutTask)
{
    cancellationTokenSource.Cancel();
    cancellationTokenSource = null;
    throw new Exception("Timeout!");
}

Stocks.ItemsSource = allStocksLoadingTask.Result.SelectMany(stocks => stocks);
```


### Precomputed Results of a Task

Fake an sync method (such as in a mock of a service) using options like `Task.FromResult`
```
return Task.FromResult(myInMemoryTestData.Where(stock => stock.Ticker == ticker));
```


### Process tasks as they complete

```
var service = new StockService();
var stocks = new ConcurrentBag<StockPrice>(); //thread safe. Normal List<T> is not.

var tickerLoadingTasks = new List<Task<IEnumerable<StockPrice>>>();
        foreach (var ticker in tickers)
        {
            var loadTask = service.GetStockPricesFor(ticker, cancellationTokenSource.Token)
                .ContinueWith(t =>
                {
                    foreach (var stock in t.Result.Take(5)) stocks.Add(stock);

                    Dispatcher.Invoke(() =>
                    {
                        Stocks.ItemsSource = stocks.ToArray();
                    });

                    return t.Result; //otherwise would return a Task
                });

            tickerLoadingTasks.Add(loadTask);
        }

await Task.WhenAll(tickerLoadingTasks);

```

### Controlling the continuations

eg: `.ConfigureAwait(false)` useful when you don't care about the original context. Method scoped. Dropped in ASP.NET Core which does not leverage a synchroniation context. Ideally just avoid.



### Parallel Extensions (leverages TPL under the hood)

Parallel programming lets you break down a problem and compute each piece independently.

```
Parallel.Invoke(new ParallelOptions { CancellationToken = cancellationTokenSource.Token
    },
        () =>
        {
                                
            Debug.WriteLine("Starting Operation 1");                                        
            CalculateExpensiveComputation(loadedStocks);   
            Debug.WriteLine("Completed Operation 1");                                       
        },
        () =>
        {                                        
            Debug.WriteLine("Starting Operation 2");                                       
            CalculateExpensiveComputation(loadedStocks);
            Debug.WriteLine("Completed Operation 2");
            #endregion
        }                                   
)
```
Note: Parallel.Invoke is blocking.

(skipped a bit)

### Async Deep Dive

Compare

```
public async Task<string> ReadFile(){
    var data = await File.ReadAllTextASync("x.txt");
    return data;
} 
```

```
public Task<string> ReadFile(){
    return File.ReadAllTextASync("x.txt"); //returns a reference to the task
} 
```

Both work, but async/await creates a state machine. The second is faster and makes most sense as we are not doing anything in the continuation. The first is safer.

The Task Completion Source is used to introduce a task into the app .. skipped

### Implications of async/await

The state machine tracks tasks in the current context and executes the continuation on the correct context. Each async method has it's own state machine.
