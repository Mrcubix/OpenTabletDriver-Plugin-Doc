# Tools

```csharp
[PluginName("My Name")]
public class MyBinding : ITool
{
    public bool Initialize()
    {
        // do something
        return true;
    }

    public void Dispose()
    {
        // do something
    }
}
```

Tools are not part of the pipeline and are used to either provide an interface to some bindings or as a bridge to external applications.

```{warning}
You should run your code in a separate thread or task to avoid blocking the driver.
```

Tools are last in the chain of initialization.

You can make your tool configurable by the user by adding properties to your class.

```csharp
[Property("Numerical Input Box Property"),
 Unit("Some Unit Here"),
 DefaultPropertyValue(727),
 ToolTip("Filter template:\n\n" +
         "A property that appear as an input box.\n\n" +
         "Has a numerical value.")]
public int ExampleNumericalProperty { get; set; }

[Property("String Type Input Box Property"),
 DefaultPropertyValue("727"),
 ToolTip("Filter template:\n\n" +
         "A property that appear as an input box.\n\n" +
         "Has a string value.")]
public string ExampleStringProperty { get; set; }

[BooleanProperty("Boolean Property", ""),
 DefaultPropertyValue(true),
 ToolTip("Area Randomizer:\n\n" +
         "A property that appear as a check box.\n\n" +
         "Has a Boolean value")]
public bool ExampleBooleanProperty { set; get; }

// 0.6.x Only
[Property("Validated Property"),
 DefaultPropertyValue("Two"),
 PropertyValidated(nameof(SomeChoice))]
public string SomeValidatedProperty { get; set; } = string.Empty;

public static IEnumerable<string> SomeChoice { get; set; } = new List<string> { "One", "Two", "Three" };
```

```{image} img/plugin-properties.png
:alt: Plugin Properties
:align: center
```

<br>

```{note}
The Enumerable used for a `PropertyValidated` must be a static field.
```

<br>