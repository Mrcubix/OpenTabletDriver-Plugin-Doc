# Fetching the Output Mode

::::{tabs}
:::{tab} 0.6.6.2

To fetch the output mode, you need to first fetch the associated tablet's input device tree.
The tree in question can be acquired from a `OpenTabletDriver.Driver` instance.

```csharp
[Resolved]
public IDriver Driver { get; set; }

[TabletReference]
public TabletReference Tablet
{
    get => _tablet;
    set
    {
        _tablet = value;
        // The Tablet's Reference is fed after the Driver, so it is safe to call Initialize() here
        Initialize();
    }
}

public void Initialize()
{
    if (Driver is Driver driver)
    {
        // The plugin and the Output Mode (which is also a plugin) shares the same instance of TabletReference, which is how we can identify the owning tree.
        InputDeviceTree tree = driver.InputDevices.FirstOrDefault(dev => dev.OutputMode.Tablet == _tablet);

        if (tree == null || tree.InputDevices.Count == 0)
        {
            Log.Write("My Plugin", "Oh no! Failed to find the tablet's input device tree.");
            return;
        }

        IOutputMode outputMode = tree.OutputMode;
    }
}
```

```{admonition} About OpenTabletDriver.Driver
:class: note
The <a href="https://github.com/OpenTabletDriver/OpenTabletDriver/blob/0.6.x/OpenTabletDriver/Driver.cs">OpenTabletDriver.Driver</a> class has tons of useful properties that could be of use to you.
```
:::
:::{tab} 0.5.3.3

The output mode can be acquired from a globally shared `OpenTabletDriver.Driver` instance.

```csharp
IOutputMode outputMode = Info.Driver.OutputMode
```

```{admonition} About OpenTabletDriver.Driver
:class: note
The <a href="https://github.com/OpenTabletDriver/OpenTabletDriver/blob/v0.5.3.3/OpenTabletDriver/Driver.cs">OpenTabletDriver.Driver</a> class has tons of useful properties that could be of use to you.
```
:::
::::