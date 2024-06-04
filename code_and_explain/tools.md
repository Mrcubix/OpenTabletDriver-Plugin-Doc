# Tools

```csharp
[PluginName("My Name")]
public class MyBinding : ITool
{
    public bool Initialize()
    {
        // do something
        return true;
    }
}
```

Tools are the last type of plugin to be initialized. They are not part of the pipeline and are used to either provide an interface to some bindings or as a bridge to external applications.

You can make your tool configurable by the user by adding properties to your class.

```csharp
[Property("Numerical Input Box Property"),
 Unit("Some Unit Here"),
 DefaultPropertyValue(727),
 ToolTip("Filter template:\n\n" +
         "A property that appear as an input box.\n\n" +
         "Has a numerical value.")]
public int ExampleNumericalProperty { get; set; }

[Property("String Type Input Box Property"),
 DefaultPropertyValue("727"),
 ToolTip("Filter template:\n\n" +
         "A property that appear as an input box.\n\n" +
         "Has a string value.")]
public int ExampleStringProperty { get; set; }

[BooleanProperty("Boolean Property", ""),
 DefaultPropertyValue(true),
 ToolTip("Area Randomizer:\n\n" +
         "A property that appear as a check box.\n\n" +
         "Has a Boolean value")]
public bool ExampleBooleanProperty { set; get; }
```

```{image} img/plugin-properties.png
:alt: Plugin Properties
:align: center
```

<br>