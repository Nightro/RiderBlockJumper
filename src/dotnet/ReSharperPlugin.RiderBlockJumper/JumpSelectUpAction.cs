using JetBrains.Application.DataContext;
using JetBrains.Application.UI.Actions;
using JetBrains.Application.UI.ActionsRevised.Menu;

namespace ReSharperPlugin.RiderBlockJumper
{
    [Action("JumpSelectUpAction", "Jump to the closest block edge above the cursor, adding to the active selection")]
    public class JumpSelectUpAction : JumpBaseAction
    {
        public override void Execute(IDataContext context, DelegateExecute nextExecute)
        {
            ExecuteJumpSelect(context, JumpDirection.Up);
        }
    }
}