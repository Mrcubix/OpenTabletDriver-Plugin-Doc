using System.Collections.Generic;
using OpenTabletDriver.Plugin;
using OpenTabletDriver.Plugin.Attributes;

namespace Samples.Tool
{
    [PluginName("My Tool")]
    public class MyTool : ITool
    {
        public bool Initialize()
        {
            // do something
            return true;
        }

        public void Dispose()
        {
            // do something
        }

        [Property("Numerical Input Box Property"),
         Unit("Some Unit Here"),
         DefaultPropertyValue(727),
         ToolTip("Filter template:\n\n" +
                 "A property that appear as an input box.\n\n" +
                 "Has a numerical value.")
        ]
        public int ExampleNumericalProperty { get; set; }

        [Property("String Type Input Box Property"),
         DefaultPropertyValue("727"),
         ToolTip("Filter template:\n\n" +
                 "A property that appear as an input box.\n\n" +
                 "Has a string value.")
        ]
        public string ExampleStringProperty { get; set; }

        [BooleanProperty("Boolean Property", ""),
         DefaultPropertyValue(true),
         ToolTip("Area Randomizer:\n\n" +
                 "A property that appear as a check box.\n\n" +
                 "Has a Boolean value")
        ]
        public bool ExampleBooleanProperty { set; get; }

#if NET6_0 
        // 0.6.x Only
        [Property("Validated Property"),
         DefaultPropertyValue("Two"),
         PropertyValidated(nameof(SomeChoice))
        ]
        public string SomeValidatedProperty { get; set; }

        public static IEnumerable<string> SomeChoice { get; set; } = new List<string> { "One", "Two", "Three" };
#endif
    }
}
