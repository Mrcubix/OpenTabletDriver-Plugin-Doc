# Logging

OpenTabletDriver provides the ability to log content to the driver's Daemon (And UX).
It is usually done using static methods in the OpenTabletDriver.Plugin.Log class.

::::{tabs}
:::{tab} 0.6.6.2
```csharp
/// <summary>
/// Invoke sending a log message.
/// </summary>
public static void Write(LogMessage message);

/// <summary>
/// Write to the log event with a group, the text, and a log level.
/// </summary>
public static void Write(string group, string text, LogLevel level = LogLevel.Info, bool createStackTrace = false, bool notify = false);

/// <summary>
/// Writes to the log event with a group, text and severity level, creating a notification in the user's
/// desktop environment.
/// </summary>
public static void WriteNotify(string group, string text, LogLevel level = LogLevel.Info);

/// <summary>
/// Writes to the log event with a group and text to with the debug severity level.
/// </summary>
public static void Debug(string group, string text);

/// <summary>
/// Writes to the log event with an exception, encoding its stack trace.
/// </summary>
public static void Exception(Exception ex, LogLevel level = LogLevel.Error);
```
Examples :
```csharp
Log.Write("My Plugin Group", "Hello World!", LogLevel.Info);
Log.Debug("My Plugin Debug Group", "This message is only visible when Debug is selected in the UX");
Log.Exception(new ThrewHarderThanIBPDuringKatowice2014Exception("Oh no something broke !"), LogLevel.Fatal);
```
```{admonition} About WriteNotify
:class: seealso
See '[](#notifications)' for more details.
```
```{admonition} Source Code
:class: seealso
See <a href="https://github.com/OpenTabletDriver/OpenTabletDriver/blob/0.6.x/OpenTabletDriver.Plugin/Log.cs">the OpenTabletDriver.Plugin.Log class</a> for more details.
```
:::
:::{tab} 0.5.3.3
```csharp
/// <summary>
/// Write to the log event with a group, the text, and a log level.
/// </summary>
public static void Write(string group, string text, LogLevel level = LogLevel.Info);

/// <summary>
/// Writes to the log event with a group and text to with the debug severity level.
/// </summary>
public static void Debug(string group, string text);

/// <summary>
/// Writes to the log event with an exception, encoding its stack trace.
/// </summary>
public static void Exception(Exception ex);
```
```csharp
Log.Write("My Plugin Group", "Hello World!", LogLevel.Info);
Log.Debug("My Plugin Debug Group", "This message is only visible when Debug is selected in the UX");
Log.Exception(new ThrewHarderThanIBPDuringKatowice2014Exception("Oh no something broke !"));
```
```{admonition} Source Code
:class: seealso
See <a href="https://github.com/OpenTabletDriver/OpenTabletDriver/blob/v0.5.3.3/OpenTabletDriver.Plugin/Log.cs">the OpenTabletDriver.Plugin.Log class</a> for more details.
```
:::
::::