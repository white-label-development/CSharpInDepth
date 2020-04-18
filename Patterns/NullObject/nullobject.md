## The Null Object Pattern

tl;dr; Don't return null. Should really be named DefaultObject Pattern.

### Return a null object instead of null

```
// hmnnnn...
public class NullPerson: IPerson{
    public string FirstName => return "A Default Value";    
}
```

Not a fan of this pattern. Investigate the Optional or Maybe pattern.