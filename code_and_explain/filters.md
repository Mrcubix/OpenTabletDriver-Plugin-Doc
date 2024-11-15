# Filters

::::{tabs}
:::{tab} 0.6.4.0
```csharp
[PluginName("My Name")]
public class MyFilter : IPositionedPipelineElement<IDeviceReport>
{
    public PipelinePosition Position => PipelinePosition.PreTransform;

    public event Action<IDeviceReport>? Emit;

    // Any reports, including positionals, are received here
    public void Consume(IDeviceReport report)
    {
        // report are emitted to other elements in the pipeline
        Emit?.Invoke(report);
    }
}
```
:::
:::{tab} 0.5.3.3
```csharp
[PluginName("My Name")]
public class MyFilter : IFilter
{
    public FilterStage FilterStage => FilterStage.PreTranspose;

    // Position is received here
    public Vector2 Filter(Vector2 value)
    {
        return value;
    }
}
```
:::
::::

In 0.6.x, You are able to alter positionnal reports via the `Consume()` method, which is called on every report. \
You can also choose to not emit a positionnal report to prevent it from going further in the pipeline.

In 0.5.x, you are able to alter positionnal reports via the `Filter` method, which is called on every report. \
You may discard the report by returning `Vector2.Zero` or less if the user has `Ignore output outside area` is enabled.

Filters can choose to be called at two different stages of the pipeline by changing the value of `Position`. \
The possible values are :
- Before the transformation: `PipelinePosition.PreTransform` (0.6.x) / `FilterStage.PreTranspose` (0.5.x),
- After the transformation: `PipelinePosition.PostTransform` (0.6.x) / `FilterStage.PostTranspose` (0.5.x)

(before or after the transformation from tablet to screen coordinates).

```{admonition} Do not block non-handled input types (0.6.x Only)
:class: danger
Plugins such as Filters should emit non-handled report types in `Consume()`.  
Failing in doing so may result in those reports being discarded.  
(Preventing Bindings set by the user from being invoked & other plugins from working properly)
```

You can make your filter configurable by the user by adding properties to your class.

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
