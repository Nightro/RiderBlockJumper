using JetBrains.Application.Settings;
using JetBrains.Application.Settings.WellKnownRootKeys;

namespace ReSharperPlugin.RiderBlockJumper
{
    [SettingsKey(typeof(EnvironmentSettings),"Settings for RiderBlockJumper")]
    public class RiderBlockJumperSettings
    {
        [SettingsEntry(DefaultValue: true, Description: "If enabled, the cursor will jump outside of the block edge (blank line), otherwise it jumps inside the block edge (text line)")]
        public bool JumpOutsideEdge;
        
        [SettingsEntry(DefaultValue: false, Description: "If enabled, the cursor will only jump to the far edge of a block, otherwise it visits every edge of a block")]
        public bool SkipClosestEdge;
    }
}