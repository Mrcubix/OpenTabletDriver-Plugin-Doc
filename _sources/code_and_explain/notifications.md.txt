# Notifications  (0.6.x Only)

Plugins can send toast notifications to the user.
Windows & MacOS are fully supported, Linux on the other hand might not be due inconsistencies in the APIs supported by different distros.

```csharp
public void SendNotification(string message) 
{
    // Group, title, message, create stacktrace, send notification
    Log.Write("My Plugin", message, LogLevel.Info, false, true);
}
```