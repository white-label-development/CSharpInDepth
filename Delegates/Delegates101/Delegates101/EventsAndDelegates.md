### Events and Delegates

ie: the progression from hardcoded delegates to the anonymous types in modern usage.




communication between objects

loosly coupled

A Delegate is the CONTRACT between publisher and subscriber. Determines the signature. Name is not important, only the sig.


#### Mosh Tutorial

eg:

`VideoEncoder` class emits/raises a VideoEncoded event. 

`MailService` and `MessageService` classes are subscribed to the event and do their thing when it's emmited. 
This decouples the classes.

```
public void OnVideoEncoded(object source, EventArgs e) { }
```

So, we define a Delegate `VideoEncodedEventHandler` and we define an Event `VideoEncoded`.

We have a publisher `VideoEncoder` and zero-or-many subscribers `MailService`.

Subscribers subscribe `videoEncoder.VideoEncoded += mailSvc.OnVideoEncoded;` and are notified when the event occurs.

Behind the scenes we are talking about the publisher maintaining a list of pointers to subscriber functions.


#### TimCorey Tutorial

With a Func we don't need to create the delegate signature, instead we define the Func inline

`Func<List<ProductModel>, decimal, decimal>`

Funcs can't be used with `out` parameters but delegates can.