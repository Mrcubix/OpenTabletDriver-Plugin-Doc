# Dependencies 

Your plugin may depend on objects, such as a reference to a tablet using the plugin or an instance of `IDriver`, and more.

::::{tabs}
:::{tab} 0.6.4.0
```csharp
[TabletReference]
public TabletReference? _tablet { get; set; }

[Resolved]
public IDriver DriverInstance { get; set; }

[Resolved]
public ITimer Timer { get; set; }

[Resolved]
public IAbsolutePointer AbsolutePointer { get; set; }

[Resolved]
public IRelativePointer RelativePointer { get; set; }

[Resolved]
public IVirtualTablet? VirtualTablet { get; set; }

[Resolved]
public IVirtualScreen VirtualScreen { get; set; }

[Resolved]
public IVirtualKeyboard VirtualKeyboard { get; set; }
```
:::
:::{tab} 0.5.3.3
```csharp
private IDriver _driverInstance = Info.Driver;

// Equivalent of TabletReference
private TabletState _tabletState = Info.TabletState;

private ITimer _timer = SystemInterop.Timer;

private IAbsolutePointer _absolutepointer = SystemInterop.AbsolutePointer;

private IRelativePointer _relativePointer = SystemInterop.RelativePointer;

// Linux only
private IVirtualTablet? _virtualTablet = SystemInterop.VirtualTablet;

private IVirtualScreen _virtualScreen = SystemInterop.VirtualScreen;

private IVirtualKeyboard _virtualKeyboard = SystemInterop.VirtualKeyboard;
```
:::
::::

```{admonition} Developing for 0.5.x
`SystemInterop` is part of the `OpenTabletDriver.Desktop.Interop` namespace.
```

```{admonition} Developing for 0.6.x
`SystemInterop` is now `DesktopInterop`, and is still part of the `OpenTabletDriver.Desktop.Interop` namespace.
```