using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Output;
using OpenTabletDriver.Plugin.Tablet;

namespace Samples.Interpolator
{
    [PluginName("My Interpolator")]
    public class MyInterpolator : AsyncPositionedPipelineElement<IDeviceReport>
    {
        public MyInterpolator() : base()
        {
        }

        public override PipelinePosition Position => PipelinePosition.PostTransform;

        /// <summary>
        ///   Updates the state of the <see cref="AsyncPositionedPipelineElement{T}"/> 
        ///   within a synchronized context.
        ///   This is invoked by the <see cref="Scheduler"/> on the interval defined by 
        ///   <see cref="Frequency"/>.
        ///   The implementer must invoke <see cref="OnEmit"/> 
        ///   to continue the input pipeline.
        /// </summary>
        protected override void UpdateState()
        {
            if (State is ITabletReport report && PenIsInRange())
                OnEmit();
        }

        /// <remarks>
        ///   This is called by <see cref="Consume"/> whenever a report is received from 
        ///   a linked upstream element.
        /// </remarks>
        protected override void ConsumeState()
        {
            // This will block any pen reports
            if (State is not ITabletReport report)
                OnEmit();
        }

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
        public string ExampleStringProperty { get; set; }

        [BooleanProperty("Boolean Property", ""),
         DefaultPropertyValue(true),
         ToolTip("Area Randomizer:\n\n" +
                 "A property that appear as a check box.\n\n" +
                 "Has a Boolean value")]
        public bool ExampleBooleanProperty { set; get; }

        [Property("Validated Property"),
         DefaultPropertyValue("Two"),
         PropertyValidated(nameof(SomeChoice))
        ]
        public string SomeValidatedProperty { get; set; } = string.Empty;

        public static IEnumerable<string> SomeChoice { get; set; } = new List<string> { "One", "Two", "Three" };
    }
}
