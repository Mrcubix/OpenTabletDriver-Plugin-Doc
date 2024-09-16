# Settings Wipe (0.6.x Only)

When using the `OnDependencyLoad` Attribute, any unhandled exception will cause the settings to be wiped.
Normally, OpenTabletDriver would revert to the previous settings, but unfortunately, it does not and will wipe settings.