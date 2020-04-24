using System.Linq;
using JetBrains.Application.DataContext;
using JetBrains.Application.Settings;
using JetBrains.Application.UI.Actions;
using JetBrains.Application.UI.ActionsRevised.Menu;
using JetBrains.DocumentModel;
using JetBrains.ProjectModel;
using JetBrains.TextControl;
using JetBrains.Util;
using JetBrains.Util.dataStructures.TypedIntrinsics;

namespace ReSharperPlugin.RiderBlockJumper
{
    public abstract class JumpBaseAction : IExecutableAction
    {
        protected enum JumpDirection
        {
            Up,
            Down
        }
        
        public bool Update(IDataContext context, ActionPresentation presentation, DelegateUpdate nextUpdate)
        {
            var textControl = context.GetData(JetBrains.TextControl.DataContext.TextControlDataConstants.TEXT_CONTROL);
            return textControl != null && textControl.Window.IsFocused.Value;
        }

        public abstract void Execute(IDataContext context, DelegateExecute nextExecute);

        protected void ExecuteJump(IDataContext context, JumpDirection direction)
        {
            var solution = context.GetData(JetBrains.ProjectModel.DataContext.ProjectModelDataConstants.SOLUTION);
            if (solution == null)
                return;
            
            var textControl = context.GetData(JetBrains.TextControl.DataContext.TextControlDataConstants.TEXT_CONTROL);
            if (textControl == null)
                return;
            
            var settingsStore = solution.GetSettingsStore();
            var jumpOutsideEdge = settingsStore.GetValue((RiderBlockJumperSettings x) => x.JumpOutsideEdge);
            var skipClosestEdge = settingsStore.GetValue((RiderBlockJumperSettings x) => x.SkipClosestEdge);
            
            ExecuteJump(textControl, direction, jumpOutsideEdge, skipClosestEdge);
        }

        protected void ExecuteJumpSelect(IDataContext context, JumpDirection direction)
        {
            var solution = context.GetData(JetBrains.ProjectModel.DataContext.ProjectModelDataConstants.SOLUTION);
            if (solution == null)
                return;
            
            var textControl = context.GetData(JetBrains.TextControl.DataContext.TextControlDataConstants.TEXT_CONTROL);
            if (textControl == null)
                return;
            
            var settingsStore = solution.GetSettingsStore();
            var jumpOutsideEdge = settingsStore.GetValue((RiderBlockJumperSettings x) => x.JumpOutsideEdge);
            var skipClosestEdge = settingsStore.GetValue((RiderBlockJumperSettings x) => x.SkipClosestEdge);
            
            ExecuteJumpSelect(textControl, direction, jumpOutsideEdge, skipClosestEdge);
        }

        private void ExecuteJump(ITextControl textControl, JumpDirection direction, bool jumpOutsideEdge, bool skipClosestEdge)
        {
            var document = textControl.Document;
            var caretPos = textControl.Caret.Position.Value;
            var caretDocumentPos = caretPos.ToDocLineColumn();

            var lineCount = document.GetLineCount();
            var lineInc = direction == JumpDirection.Down ? Int32<DocLine>.I : Int32<DocLine>.O - Int32<DocLine>.I;
            var targetLine = Int32<DocLine>.MinValue;
            var firstLine = caretDocumentPos.Line + lineInc;
            var previousLine = caretDocumentPos.Line;
            var previousLineIsBlank = string.IsNullOrWhiteSpace(document.GetLineText(previousLine));
            for (var line = firstLine; line >= Int32<DocLine>.O && line < lineCount; line += lineInc)
            {
                if (!skipClosestEdge && previousLineIsBlank && line != firstLine)
                {
                    // found our text block, go to the blank line right before it
                    targetLine = (jumpOutsideEdge) ? previousLine : line;
                    break;
                }

                var lineText = document.GetLineText(line);
                var lineIsBlank = string.IsNullOrWhiteSpace(lineText);
                if (lineIsBlank)
                {
                    if (!previousLineIsBlank && line != firstLine)
                    {
                        // found our next blank line beyond our text block
                        targetLine = (jumpOutsideEdge) ? line : previousLine;
                        break;
                    }
                }

                previousLine = line;
                previousLineIsBlank = lineIsBlank;
            }

            int finalOffset = 0;
            if (targetLine >= Int32<DocLine>.O)
            {
                if (jumpOutsideEdge)
                {
                    // move the caret to the blank line
                    finalOffset = document.GetLineEndOffsetNoLineBreak(targetLine);
                }
                else
                {
                    // move the caret to the first character on the non-blank line
                    string lineString = document.GetLineText(targetLine);
                    int spaceOffset = lineString.TakeWhile(char.IsWhiteSpace).Count();
                    finalOffset = document.GetLineStartOffset(targetLine) + spaceOffset;
                }
            }
            else
            {
                // we found no suitable position so just go to BOF or EOF depending on the direction
                if (direction == JumpDirection.Up)
                {
                    finalOffset = document.GetDocumentStartOffset().Offset;
                }
                else
                {
                    finalOffset = document.GetDocumentEndOffset().Offset;
                }
            }
            textControl.Caret.MoveTo(finalOffset, CaretVisualPlacement.DontScrollIfVisible);
        }
        
        private void ExecuteJumpSelect(ITextControl textControl, JumpDirection direction, bool jumpOutsideEdge, bool skipClosestEdge)
        {
            // in the case of a disjoint selection we just wipe it all and start where the caret is, otherwise we add to
            // the active selection - maybe in future we'll support disjoint jumping...
            var startPos = textControl.Caret.Position.Value;
            if (textControl.Selection.HasSelection() && !textControl.Selection.IsDisjoint())
            {
                startPos = textControl.Selection.GetAnchorPoint();
            }
            
            ExecuteJump(textControl, direction, jumpOutsideEdge, skipClosestEdge);
            
            var endPos = textControl.Caret.Position.Value;
            if (textControl.Selection.IsDisjoint())
            {
                textControl.Selection.Collapse();
            }
            textControl.Selection.SetRange(new TextRange(startPos.ToDocOffset(), endPos.ToDocOffset()));
        }
    }
}