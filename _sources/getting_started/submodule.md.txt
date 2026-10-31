# Github Submodule

A git submodule allows you to include a repository inside another repository. \
Using this method, you will be able to include other parts of the driver, like `OpenTabletDriver.Desktop`, which contains many useful classes and methods
such as `AppInfo` (A class that store information such as paths & even a shared instance to the Plugin Manager).
You'll also be able to view and look into the source code of the driver, which can be useful for debugging or understanding how the driver works.

you can add OpenTabletDriver as a submodule by running the following command in the root of your repository:

```bash
git submodule add https://github.com/OpenTabletDriver/OpenTabletDriver.git .modules/OpenTabletDriver
git -c .modules/OpenTabletDriver checkout v0.5.3.3
```

```{warning}
Although i'm checking out at 0.5.3.3, you should check out at the version you intend to make the plugin for. \
Plugins usually work across minor versions but occasionally there may be breaking changes to the plugin library.
```

Once that is done, to add `OpenTabletDriver.Desktop` as a project reference, for example, you can add the following to your `.csproj` file:

```xml
<ItemGroup>
    <ProjectReference Include=".modules/OpenTabletDriver/OpenTabletDriver.Desktop/OpenTabletDriver.Desktop.csproj" />
</ItemGroup>
```