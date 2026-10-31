# Plugin Memory Leak (Fixed in 0.6.5.1)

OpenTabletDriver does not properly dispose of plugins, especially when a tablet is disconnected. \
When a tablet is reconnected, it is very likely that a new instance of the plugin will be created, while the old instance is still in use. \
There are workarounds to avoid such leak, but it requires fetching the device from the driver itself and subscribing to the `ConnectionStateChanged` event on `IDeviceReader`.