# Plugin Race Conditions (0.6.x Only)

OpenTabletDriver may not feed all dependencies in time for plugin initialization, \
even when using the `OnDependencyLoad` attribute. \
You may want to call your initialization method from inside the setter of the property.

```csharp
private IDriver _driverInstance;

[Resolved]
public IDriver DriverInstance
{
    get => _driver;
    set
    {
        _driver = value;
        Initialize();
    }
}
```

Additionally, you should be aware of the order of initialization for the different types of plugins, previously mentionned in [Plugin Types & features](#plugin_types).
