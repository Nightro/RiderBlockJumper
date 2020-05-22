using JetBrains.Application.UI.Options;
using JetBrains.Application.UI.Options.Options.ThemedIcons;
using JetBrains.Application.UI.Options.OptionsDialog;
using JetBrains.IDE.UI.Options;
using JetBrains.Lifetimes;
using JetBrains.Application.UI.Options.OptionPages;

namespace ReSharperPlugin.RiderBlockJumper.Options
{
    [OptionsPage(Id, PageTitle, typeof(OptionsThemedIcons.EnvironmentGeneral), ParentId = EnvironmentEditorPage.PID)]
    public class RiderBlockJumperOptionsPage : BeSimpleOptionsPage
    {
        private const string Id = "RiderBlockJumperOptionsPage";
        private const string PageTitle = "Block Jumper Options";

        private readonly Lifetime _lifetime;

        public RiderBlockJumperOptionsPage(
            Lifetime lifetime,
            OptionsPageContext optionsPageContext,
            OptionsSettingsSmartContext optionsSettingsSmartContext)
            : base(lifetime, optionsPageContext, optionsSettingsSmartContext)
        {
            _lifetime = lifetime;
            
            AddHeader("General");
            AddBoolOption((RiderBlockJumperSettings x) => x.JumpOutsideEdge, "Jump Outside Edge", "If enabled, the cursor will jump outside of the block edge (blank line), otherwise it jumps inside the block edge (text line)");
            AddBoolOption((RiderBlockJumperSettings x) => x.SkipClosestEdge, text: "Skip Closest Edge", toolTipText: "If enabled, the cursor will only jump to the far edge of a block, otherwise it visits every edge of a block");
        }
    }
}