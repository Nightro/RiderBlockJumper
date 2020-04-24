using JetBrains.Application.DataContext;
using JetBrains.Application.UI.Actions;
using JetBrains.Application.UI.ActionsRevised.Menu;

namespace ReSharperPlugin.RiderBlockJumper
{
    [Action("JumpDownAction", "Jump to the closest block edge below the cursor")]
    public class JumpDownAction : JumpBaseAction
    {
        public override void Execute(IDataContext context, DelegateExecute nextExecute)
        {
            ExecuteJump(context, JumpDirection.Down);
        }
    }
}