using JetBrains.Application.DataContext;
using JetBrains.Application.UI.Actions;
using JetBrains.Application.UI.ActionsRevised.Menu;

namespace ReSharperPlugin.RiderBlockJumper
{
    [Action("JumpUpAction", "Jump to the closest block edge above the cursor")]
    public class JumpUpAction : JumpBaseAction
    {
        public override void Execute(IDataContext context, DelegateExecute nextExecute)
        {
            ExecuteJump(context, JumpDirection.Up);
        }
    }
}