# Plugin types & features

OpenTabletDriver has five main types of plugins: filters, interpolators, output modes, bindings and tools. \
Plugins like filter, interpolators & output modes are part of the input pipeline and are used to process reports for use by either the pointer or other plugins.

## Filters

**Filters** can be used to read, modify or even discard reports. These are most commonly used to apply smoothing algorithms to positional data. \
They are not disposed of whenever a device is disconnected, only either when settings are applied or a new device is connected.
 \
They are initialized at the same time as interpolators.
Their settings is shared between all tablets.

```{note}
In 0.6.x, each tablet has their own instance of filters & settings
```

## Interpolators

**Interpolators** can be used the same way as filters, but are run at a set frequency by the user. A common use it to fill the gap between two reports. \
They are initialized at the same time as filters.

```{note}
In 0.6.x, each tablet has their own instance of interpolators & setting
```

## Output Modes

**Output modes** are the most important part of the pipeline. They receive reports from the parser, send them to each elements of the pipeline, then pass the result to the pointer, which usually is responsible for moving the cursor or other trigerring functionalities depending on the Operating System's API. \
 \
OpenTabletDriver has two types of output modes: **Absolute** and **Relative**.

The **Absolute output mode** will move the cursor depending on the position of the pen on the tablet, going out of range and back will result in the cursor jumping. \
As for the **Relative output mode**, it will move the cursor relative to the last known position like a mouse.

It is the first type of plugin to be initialized.

```{note}
In 0.6.x, each tablet has their own instance of output modes & settings
```

## Bindings

**Bindings** are not part of the pipeline and are used to trigger actions when a specific report is received, like a click, a key press, and others. \
 \
They are usually initialized before the filters & interpolators.

```{note}
In 0.6.x, each tablet has their own settings for bindings
```

## Tools

**Tools** also are not part of the pipeline and are used to either provide an interface to some bindings or as a bridge to external applications. \
 \
They are usually the last type of plugin to be initialized.