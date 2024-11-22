# Debugging with VSCode

The base C# extension from Visual Studio Code allows you to attach the debugger to any C# .NET process running on your system.
This can be used to debug your plugins, by attaching to `OpenTabletDriver.Daemon`.

You can add the following json chunk to your launch.json file:

```json
{
    "name": "OpenTabletDriver Plugin Debugging",
    "type": "coreclr",
    "request": "attach",
    "requireExactSource": false,
    "processName": "OpenTabletDriver.Daemon",
    "logging": {
        "moduleLoad": false
    },
},
```

Now provided that you build your plugin with debug configuration, and either embed the PDB file or place it in the same location as your installed plugin, 
you should be to just go to `Run` > `Start Debugging` or switch to your debug tab in the vscode sidebar, select the new launch configuration & press the run button.