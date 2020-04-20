using JetBrains.Application.DataContext;
using JetBrains.Application.UI.Actions;
using JetBrains.Application.UI.ActionsRevised.Menu;
using JetBrains.Application.UI.ActionSystem.ActionsRevised.Menu;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Psi.Files;
using JetBrains.TextControl;
using JetBrains.TextControl.Util;
using JetBrains.Util;

namespace ReSharperPlugin.RiderBlockJumper
{
    [Action("SampleAction", "Do Something")]
    public class SampleAction : IActionWithExecuteRequirement, IExecutableAction
    {
        public IActionRequirement GetRequirement(IDataContext dataContext)
        {
            return CommitAllDocumentsRequirement.TryGetInstance(dataContext);
        }

        public bool Update(IDataContext context, ActionPresentation presentation, DelegateUpdate nextUpdate)
        {
            return true;
        }

        public void Execute(IDataContext context, DelegateExecute nextExecute)
        {
            ISolution solution = context.GetData(JetBrains.ProjectModel.DataContext.ProjectModelDataConstants.SOLUTION);
            ITextControl textControl = context.GetData(JetBrains.TextControl.DataContext.TextControlDataConstants.TEXT_CONTROL);
            MessageBox.ShowInfo("Info!");
        }
    }
}