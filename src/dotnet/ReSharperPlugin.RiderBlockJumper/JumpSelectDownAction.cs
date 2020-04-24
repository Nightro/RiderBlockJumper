using JetBrains.Application.DataContext;
using JetBrains.Application.UI.Actions;
using JetBrains.Application.UI.ActionsRevised.Menu;

namespace ReSharperPlugin.RiderBlockJumper
{
    [Action("JumpSelectDownAction", "Jump to the closest block edge below the cursor, adding to the active selection")]
    public class JumpSelectDownAction : JumpBaseAction
    {
        public override void Execute(IDataContext context, DelegateExecute nextExecute)
        {
            ExecuteJumpSelect(context, JumpDirection.Down);
        }
    }
}