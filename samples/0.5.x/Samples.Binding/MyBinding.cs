using System;
using OpenTabletDriver.Plugin;
using OpenTabletDriver.Plugin.Attributes;

namespace Samples.Binding
{
    [PluginName("My Binding")]
    public class MyBinding : IBinding
    {
        [Property("Property")]
        public string Property { set; get; } = string.Empty;

        public Action Press
        {
            get => () =>
            {
                // do something depending on <see cref="Property"/>
            };
        }

        public Action Release
        {
            get => () =>
            {
                // do something depending on <see cref="Property"/>
            };
        }

        /// <summary>
        /// A list of valid keys for this category
        /// </summary>
        public string[] ValidProperties => new string[] { "Option 1", "Option 2" };

        public override string ToString() => $"My Binding: {Property}";
    }
}