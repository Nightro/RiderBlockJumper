using JetBrains.Application.Settings;
using JetBrains.Application.Settings.WellKnownRootKeys;

namespace ReSharperPlugin.RiderBlockJumper
{
    [SettingsKey(
        typeof(EnvironmentSettings),
//        typeof(CodeEditingSettings),
        "Settings for RiderBlockJumper")]
    public class SampleSettings
    {
        [SettingsEntry(DefaultValue: "<default>", Description: "Sample Description")]
        public string SampleText;
    }
}