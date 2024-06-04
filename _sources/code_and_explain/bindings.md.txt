# Bindings

::::{tabs}
:::{tab} 0.5.3.3
```csharp
[PluginName("My Binding")]
public class MyBinding : IBinding, IValidateBinding
{
    [Property("Property")]
    public string Property { set; get; } = string.Empty;

    public Action Press
    {
        get => () => {
            // do something depending on <see cref="Property"/>
        };
    }

    public Action Release
    {
        get => () => {
            // do something depending on <see cref="Property"/>
        };
    }

    /// <summary>
    /// A list of valid keys for this category
    /// </summary>
    public string[] ValidProperties => new string[] { "Option 1", "Option 2" };

    public override string ToString() => $"My Binding: {Property}";
}
```
:::
:::{tab} 0.6.4.0
```csharp
[PluginName("My Binding")]
public class MyBinding : IStateBinding
{
    [Property("Key"), PropertyValidated(nameof(ValidKeys))]
    public string Key { set; get; } = string.Empty;

    public void Press(TabletReference tablet, IDeviceReport report)
    {
        // do something depending on <see cref="Key"/>
    }

    public void Release(TabletReference tablet, IDeviceReport report)
    {
        // do something depending on <see cref="Key"/>
    }

    /// <summary>
    /// A list of valid keys for this category
    /// </summary>
    public static IEnumerable<string> ValidKeys => new List<string> { "Option 1", 
                                                                      "Option 2" };

    public override string ToString() => $"My Binding: {Key}";
}
```
:::
::::

Bindings from plugins can only get selected by the user from the Advanced Binding Editor. \
Any options in the `ValidKeys` array will be displayed in the UI as a dropdown list of 'My Binding'.

```{image} img/bindings-dropdown.png
:alt: Bindings dropdown
:align: center
```