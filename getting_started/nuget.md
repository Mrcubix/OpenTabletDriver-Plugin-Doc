# Nuget Packages

OpenTabletDriver offer multiple packages on Nuget for plugin development. \

[`OpenTabletDriver.Plugin`](https://github.com/OpenTabletDriver/OpenTabletDriver.Plugin) offers libraries to create plugins for OpenTabletDriver. \
This package is used to create filters, interpolators, output modes, bindings and tools.

[`OpenTabletDriver`](https://github.com/OpenTabletDriver/OpenTabletDriver) offers the core functionalities of the driver, which can be used to inject inputs into an application.
This is currently used in [osu!lazer](https://github.com/ppy/osu) to provide tablet support.
This package also include [`OpenTabletDriver.Plugin`](https://github.com/OpenTabletDriver/OpenTabletDriver.Plugin).

```{warning}
The package version is linked to the OpenTabletDriver version it was created for. \
Plugins may work across minor versions, but may break if major changes are made to the plugin library.
```

If these packages doesn't fit you needs, you may be interested into using git submodules instead to include other parts of the driver.