# Filters

::::{tabs}
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
::::

In 0.5.3.3, you are able to alter positionnal reports via the `Filter` method, which is called on every report. \
You may cancel the report by returning `Vector2.Zero` or less if the user has `Ignore output outside area` is enabled.

Filters can choose to be called at two different stages of the pipeline by changing the value of `Position`. \
The possible values are : `FilterStage.PreTranspose` and `FilterStage.PostTranspose` \
(before or after the transformation from tablet to screen coordinates).

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
```

```{image} img/plugin-properties.png
:alt: Plugin Properties
:align: center
```

<br>
