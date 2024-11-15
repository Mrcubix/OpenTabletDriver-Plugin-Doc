using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Tablet.Interpolator;
using OpenTabletDriver.Plugin.Timers;

// you should be able to remove this provided you use a namespace that doesn't end with Interpolator like here
using OTDInterpolator = OpenTabletDriver.Plugin.Tablet.Interpolator.Interpolator;

namespace Samples.Interpolator
{
    [PluginName("My Interpolator")]
    public class MyInterpolator : OTDInterpolator // Alias for Interpolator, taken by the namespace in this sample
    {
        private SyntheticTabletReport syntheticReport;

        public MyInterpolator(ITimer scheduler) : base(scheduler)
        {
        }

        // Position is received here
        public override SyntheticTabletReport Interpolate()
        {
            return syntheticReport;
        }

        public override void UpdateState(SyntheticTabletReport report)
        {
            syntheticReport = new SyntheticTabletReport(report);
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
        public int ExampleStringProperty { get; set; }

        [BooleanProperty("Boolean Property", ""),
         DefaultPropertyValue(true),
         ToolTip("Area Randomizer:\n\n" +
                 "A property that appear as a check box.\n\n" +
                 "Has a Boolean value")]
        public bool ExampleBooleanProperty { set; get; }
    }
}
