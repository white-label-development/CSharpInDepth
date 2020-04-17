## Events, Delegates and Lambdas (recap)


## The General Role of Events, Delegates and Event Handlers

Event Raiser - Delegate - EventArgs - Event Handler

Note: intro example used string walkie takie example where talker = event raiser, string = delgate, listener = event handler.

Events are notifications. Objects that raise events don't need to know the object that will handle the event.

A delegate is a specialized class, often called a "function pointer" (as the event handler is a function). This is the glue/pipeline between an event and an event handler. Think "delegate this data to that handler".

(In .Net we have the `MulticastDelegate` base class to communicate with the subscribers.)

The Event handler is responsible for receiving and processing data from the delegate (does not need to know about the event raiser).



##  Creation
### Delegate Creation

Delegates are created with the delegate keyword `public delegate void WorkPerformedHandler(int hours, WorkType worktype);` it's a one way pipeline in this case (as it's `void` return) and define the blueprint of the pipeline that the handler needs to adhere to. This is the _delegate definition_

So a handler for this delegate could be `public void WorkPerformed(int hours, WorkType worktype) { ... };`

In .Net there are abstract base classes used.

Delegate - the ABC inherits from MulticastDelegate (MulticastDelegate is a way to hold multiple delegates - think multiple pipelines from same event)

Method - prop: where the pipeline "dumps" the data

Target - prop: object instance containing the method

GetInvocationList() - List of delegate event handlers. Delegates are invoked sequentially.

eg:

`void WorkPerformed1(int hours, WorkType worktype) { Console.WriteLine("wp1 called") };`

`void WorkPerformed2(int hours, WorkType worktype) { Console.WriteLine("wp2 called") };`

`WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1)`

`WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2)`

`del1(5, WorkType.Golf);` // invoke the delegate to call WorkPerformed1

The above currently results in just WorkPerformed1 being run, but if we wanted one event to run two handlers 

`del1 += del2` // adds del2 to the invocation list. Now del1(5, WorkType.Golf);` would run both.

#### Why bother?
Loose coupling.

```
static void DoWork(WorkPerformedHandler del){
    del(5, WorkType.Golf)); 
    // del could be the delegate/pipeline to WorkPerformed1 (if we passed  in del1)
    // or the passed in delgate could go to another handler target (WorkPerformed2)
}
```

#### Delegate returning a value

`public delegate int WorkPerformedHandler(int hours, WorkType worktype);`

Simple when only one item in the invocation list as only that value gets returned, but consider...

```
del1 += del2 + del3; //each handler increments the hour by one (not shown)
int finalHours = del1(10 , WorkType.Golf)); 
Console.WriteLine(finalHours); // returns 13 as only the final value is shown (from del3)
```

AFAIK there is no way around this.

### Event Creation

`public event WorkPerformedHandler WorkPerformed;` // the _event definition_

An event on it's doesn't do anything. We need the delegate (WorkPerformedHandler) to provide the pipeline from A to B. Events are friendly wrappers around delegates. The event here is called WorkPerformed.

To call an event
```
if (WorkPerformed != null){
    WorkPerformed(8, WorkType.Foo);
}
```

Usually the format is to use the _on_ prefix. Full example:

```
public delegate void WorkPerformedHandler(int hours, WorkType worktype); 
public class Worker {

    public event WorkPerformedHandler WorkPerformed;
    public event EventHandler WorkCompleted; //not used here, just showing use of built in EventHandler for use if we have no custom data to pass.

    public virtual void DoWork(int hours, WorkType workType){
        // do something
        // and notify consumer that work as been done
        OnWorkPerformed(hours, workType);
    }

    protected virtual void OnWorkPerformed(int hours, WorkType worktype){
        // alterntive method of raising an event by casting to the delegate
        // shown here for completeness. 
        //An Event is syntactic sugar on top of a delegate - the previous example is really doing this behind the scenes.
        WorkPerformedHandler del = WorkPerformed as WorkPerformedHandler;
        if (del != null) { // listeners are attached
            del(hours, worktype); // raise event
        }
    }

}
```

Rather than use `int hours, WorkType worktype` it's better practice to create a custom `EventArgs` Class.

```
public class WorkPerformedEventArgs: System.EventArgs{
    public int Hours {get;set;}
    public WorkType WorkType {get;set;}
}

public delegate void WorkPerformedHandler(object sender, WorkPerformedEventArgs e); 

// or we can now leverage EventHandler<T>
public event EventHandler<WorkPerformedEventArgs>  WorkPerformed; 
// behind scenes same as above, but compiler will generate the delegate for this event.
```

## Handling Events

Attach an event to an event handler
```
var worker = new Worker();
worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);

worker.DoWork(9, workType.Foo); // kick the whole thing off so an event gets raised

//gets called when worker raises the WorkPerformed event
void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e){ ... };
```

a neater version of the above uses Delegate Inference (to infer the delegate from the targets method, in this case from `WorkPerformedEventArgs e`)

```
worker.WorkPerformed += Worker_WorkPerformed; // infer delegate
```

#### Using Anonymous Methods

Not usually used (lamdas are used instead)
```
var worker = new Worker();
worker.WorkPerformed += delegate(object sender, WorkPerformedEventArgs e){ ... }; //replaces need for Worker_WorkPerformed method
```


### Lambdas

Great for short logic that does not need re-use.

```
var worker = new Worker();
worker.WorkPerformed += (s, e) => Console.WriteLine("foo"); // replaces Worker_WorkPerformed function. Compiler figures out s and e.
```

Another simple example of passing a delegate into a function:
```
public delegate int BizRulesDelegate(int x, int y);

BizRulesDelegate addDel = (x,y) => x + y;
BizRulesDelegate multiplyDel = (x,y) => x * y;

data.Process(2,3,addDelegate); // ie: the delegate type can be choses at run time
```

where we have a class with a `Process(int x, int y, BizRulesDelegate del)` that obviously runs the delegate parameter `del(x,y)`


 #### Action&lt;T&gt;, Func<T, TResult>

`Action` provides a built in delegate that takes a single parameter and does not return (and 15 other for multiple parameters).

`Func` provides a built in delegate that takes a single parameter and does return.

Use them when you don't need to create a custom delegate (which is often).

```
public void ProcessAction(int x, int y, Action<int, int> action){
    action(x,y); //action is void 
    Console.WriteLine("ok);
}

Action<int, int> myAction = (x,y) => Console.WriteLine(x+y); // replaces need for BizRulesDelegate

...

data.ProcessAction(2, 3, myAction);
```

Func is basically the same, but the output is the last parameter defined.

## Events and Delegates in Action

### Communicating between components

Imagine a widgit dashboard with n components and a "job" select-list.

Mediator pattern with events - all components know about the mediator and that's it.

```

public sealed class Mediator
{
    private static readonly Mediator _Instance = new Mediator();
    private Mediator {}

    public static Mediator GetInstance(){
        return _Instance;
    }

    //Instance functionality

    //JobChangedEventArgs not shown. is just a custom event args with one property Job Job {get;set;}
    public event EventHandler<JobChangedEventArgs> JobChanged;

    // the select list for "job" is the event raiser. WHen it changes, the new job gets passed to OnJobChanged eg: 
    // (in UI selectionChanged function)
    // Mediator.GetInstance().OnJobChanged(this, (Job)JobsComboBox.SelectedItem);
    
    public void OnJobChanged(object sender, Job job){
        var jobChangeDelegate = JobChanged as EventHandler<JobChangedEventArgs>;
        if(jobChangeDelegate != null){
            jobChangeDelegate(sender, new JobChangedEventArgs {Job = job});
        }
    }

    // the components subscribe to the JobChanged event

}


public class SomeJobWidgit{
    public EmployeesOnJob(){
        //subscribe
        Mediator.GetInstance().JobChanged += (s,e) => Console.WriteLine("x");
    }
}
```

### Using the BackgroundWorker component events

Replaces the hassle of Asynchronous delegates. Is this just a WPF UI thing? Ignoring.


### The role of delgates with threads

Start a new thread with a ThreadStart delegate `var t = new Thread(new ThreadStart(MyFunctionNameHere));` then `t.Start();` to run the function on the new thread.

To reconnect the new thread to the calling (GUI) thread we can use a delegate to route back.

(UI nased so skipping this)