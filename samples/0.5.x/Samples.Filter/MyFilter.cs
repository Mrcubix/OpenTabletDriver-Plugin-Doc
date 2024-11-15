using System.Numerics;
using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Tablet;

namespace Samples.Filter
{
    [PluginName("My Filter")]
    public class MyFilter : IFilter
    {
        public FilterStage FilterStage => FilterStage.PreTranspose;

        // Any reports, including positionals, are received here
        public Vector2 Filter(Vector2 position) => position;

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
    }
}
