# Output Modes

As mentionned in {ref}`Plugin Types & features <output-modes>`, there exist two types of output modes in OpenTabletDriver, Absolute and Relative.

An output mode plugin has to inherit from either of these for it to be configurable by the user in the UX. \
Otherwise, you can also provide the means to configure it via external means.

Both output modes share the same Interface being `IOutputMode`, which include the `Read()` method. it is called after the report has been parsed.

Although The `Transpose()` method is not part of the Interface, it is present in both output modes's base class and is responsible for passing the position to each plugins in the pipeline, \
as well as performing the transformation from tablet coordinates to screen coordinates.

```{warning}
The `Transpose()` cannot be overriden in 0.5.x and therefore you should not send your report to the base if you intend on using your own implementation.
```
```{note}
In 0.5.x, processing and pointer interactions are done in the same method.
```

## Absolute Output Mode

::::{tabs}
:::{tab} 0.5.3.3
```csharp
[PluginName("My Absolute(ly) Based Output Mode")]
public class MyAbsoluteOutputMode : AbsoluteOutputMode, IPointerOutputMode<IAbsolutePointer>
{
    // OpenTabletDriver provide a pointer suitable for the current operating system, if supported.
    public override IAbsolutePointer Pointer => SystemInterop.AbsolutePointer;

    public override void Read(IDeviceReport report)
    {
        // Maybe you need to handle a type of report the base class doesn't handle
        // or maybe you want to override a behavior for a specific type of report.
        base.Read(report);
    }
}
```
:::
:::{tab} 0.6.4.0
```csharp
[PluginName("My Absolute(ly) Based Output Mode")]
public class MyAbsoluteOutputMode : AbsoluteOutputMode, IPointerProvider<IAbsolutePointer>
{
    [Resolved]
    public override IAbsolutePointer Pointer { set; get; }

    // Handle a report that just got parsed
    public override void Read(IDeviceReport deviceReport)
    {
        base.Read(deviceReport);
    }

    protected override IAbsolutePositionReport Transform(IAbsolutePositionReport report)
    {
        // you can apply your own transformation here
        base.Transform(report);
    }

    // Handle a report that has gone through the pipeline
    protected override void OnOutput(IDeviceReport report)
    {
        // report types check should be ordered from least to most chance of having a
        // dependency to another pointer property. for example, proximity
        // should be set before position, because in LinuxArtistMode
        // the SetPosition method is dependent on the proximity state.
        
        base.OnOutput(report);
    }
}
```
:::
::::

The cursor is only moved if the result of `Transpose()` is a `Vector2` and it is not outside the defined area while `Ignore input outside area` is enabled.

```{note}
The `Transpose()` present in the base class returns the transformed position.
```

See [AbsoluteOutputMode on Github](https://github.com/OpenTabletDriver/OpenTabletDriver/blob/v0.5.3.3/OpenTabletDriver.Plugin/Output/AbsoluteOutputMode.cs)
for more details.

## Relative Output Mode

::::{tabs}
:::{tab} 0.5.3.3
```csharp
[PluginName("My Relative(ly) Based Output Mode")]
public class MyRelativeOutputMode : RelativeOutputMode, IPointerProvider<IRelativePointer>
{
    // OpenTabletDriver provide a pointer suitable for the current operating system, if supported.
    public override IRelativePointer Pointer => SystemInterop.RelativePointer;

    public override void Read(IDeviceReport report)
    {
        // Maybe you need to handle a type of report the base class doesn't handle
        // or maybe you want to override a behavior for a specific type of report.
        base.Read(report);
    }
}
```
:::
:::{tab} 0.6.4.0
```csharp
[PluginName("My Relative(ly) Based Output Mode")]
public class MyRelativeOutputMode : RelativeOutputMode, IPointerProvider<IRelativePointer>
{
    [Resolved]
    public override IRelativePointer Pointer { set; get; }

    protected override IAbsolutePositionReport Transform(IAbsolutePositionReport report)
    {
        // you can apply your own transformation here
        base.Transform(report);
    }

    protected override void OnOutput(IDeviceReport report)
    {
        // report types check should be ordered from least to most chance of having a
        // dependency to another pointer property. for example, proximity
        // should be set before position, because in LinuxArtistMode
        // the SetPosition method is dependent on the proximity state.
        
        base.OnOutput(report);
    }
}
```
:::
::::

```{note}
The `Transpose()` present in the base class returns the delta between the last and the current position instead of the transformed position.
```

See [RelativeOutputMode on Github](https://github.com/OpenTabletDriver/OpenTabletDriver/blob/v0.5.3.3/OpenTabletDriver.Plugin/Output/RelativeOutputMode.cs)
