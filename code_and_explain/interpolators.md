# Interpolators

```{admonition} Help Wanted
:class: error
This section is incomplete. If you have experience with OpenTabletDriver's interpolators, please consider contributing to this documentation.
```

::::{tabs}
:::{tab} 0.5.3.3
```csharp
[PluginName("My Name")]
public class MyInterp : Interpolator
{
    private SyntheticTabletReport syntheticReport;

    public MyInterp(ITimer scheduler) : base(scheduler)
    {
    }

    public FilterStage FilterStage => FilterStage.PreTranspose;

    // Position is received here
    public override SyntheticTabletReport Interpolate()
    {
        return syntheticReport;
    }

    public override void UpdateState(SyntheticTabletReport report)
    {
        syntheticReport = new SyntheticTabletReport(report);
    }
}
```
:::
:::{tab} 0.6.4.0
```csharp
[PluginName("My Name")]
public class MyInterp : AsyncPositionedPipelineElement<IDeviceReport>
{
    public BezierInterp() : base()
    {
    }

    public PipelinePosition Position => PipelinePosition.PostTransform;

    public event Action<IDeviceReport>? Emit;

    /// <summary>
    ///   Updates the state of the <see cref="AsyncPositionedPipelineElement{T}"/> 
    ///   within a synchronized context.
    ///   This is invoked by the <see cref="Scheduler"/> on the interval defined by 
    ///   <see cref="Frequency"/>.
    ///   The implementer must invoke <see cref="OnEmit"/> 
    ///   to continue the input pipeline.
    /// </summary>
    protected override void UpdateState()
    {
        if (State is ITabletReport report && PenIsInRange())
            OnEmit();
    }

    /// <remarks>
    ///   This is called by <see cref="Consume"/> whenever a report is received from 
    ///   a linked upstream element.
    /// </remarks>
    protected override void ConsumeState()
    {
        if (State is not ITabletReport report)
            OnEmit();
    }
}
```
:::
::::

You can make your interpolator configurable by the user by adding properties to your class.

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
public int ExampleStringProperty { get; set; }

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