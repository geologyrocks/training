```csharp
public DateTime Date1 = DateTime.Now;

public DateTime Date2 { get => DateTime.Now }

public DateTime Date3 => DateTime.Now;
```

Event means no need to define private property with public method, just use  
`public event TypeClass x`

## Using Dotnet Framework APIs
### Exception handling
Not for finding errors, instead for reporting errors back to call stack  
Must be responded to / caught.  
```csharp
try
{
    // try something 
}

catch
{
    // try something else
}

finally 
{
    // perform unconditional tidy-up
}
```
try contains code that cause an exception  
catch decides what to do if an exception occurs  
finally block is called regardless of whether or not exception occurs  

#### Exception filters 
Can specify whether to catch a type of
```csharp
try
{
    …
}
catch (SomeException ex) when (MyFilterFuncThatReturnsBoolean(ex))
{
    …
}
```