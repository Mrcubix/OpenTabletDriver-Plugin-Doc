using OpenTabletDriver.Plugin;
using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Tablet;

namespace Samples.Binding
{
    [PluginName("My Binding")]
    public class MyBinding : IStateBinding
    {
        [Property("Property"), PropertyValidated(nameof(ValidProperties))]
        public string Property { set; get; } = string.Empty;

        public void Press(TabletReference tablet, IDeviceReport report)
        {
            // do something depending on <see cref="Property"/>
        }

        public void Release(TabletReference tablet, IDeviceReport report)
        {
            // do something depending on <see cref="Property"/>
        }

        /// <summary>
        /// A list of valid keys for this category
        /// </summary>
        public static IEnumerable<string> ValidProperties => new List<string> { "Option 1",
                                                                                "Option 2" };

        public override string ToString() => $"My Binding: {Property}";

        #region Extra Properties

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

        [Property("Validated Property"),
         DefaultPropertyValue("Two"),
         PropertyValidated(nameof(SomeChoice))
        ]
        public string SomeValidatedProperty { get; set; }

        public static IEnumerable<string> SomeChoice { get; set; } = new List<string> { "One", "Two", "Three" };

        #endregion
    }
}