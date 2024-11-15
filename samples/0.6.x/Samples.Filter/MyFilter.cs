using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Output;
using OpenTabletDriver.Plugin.Tablet;

namespace Samples.Filter
{
    [PluginName("My Filter")]
    public class MyFilter : IPositionedPipelineElement<IDeviceReport>
    {
        public PipelinePosition Position => PipelinePosition.PreTransform;

        public event Action<IDeviceReport> Emit;

        // Any reports, including positionals, are received here
        public void Consume(IDeviceReport report)
        {
            // report are emitted to other elements in the pipeline
            Emit?.Invoke(report);
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

        [Property("Validated Property"),
         DefaultPropertyValue("Two"),
         PropertyValidated(nameof(SomeChoice))
        ]
        public string SomeValidatedProperty { get; set; }

        public static IEnumerable<string> SomeChoice { get; set; } = new List<string> { "One", "Two", "Three" };
    }
}
