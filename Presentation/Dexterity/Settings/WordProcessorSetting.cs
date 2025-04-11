using Syncfusion.Blazor.RichTextEditor;

namespace Dexterity.Settings;

public static class WordProcessorSetting
{
    public static readonly List<ToolbarItemModel> MsWordTools = new()
    {
        // new ToolbarItemModel() {Command = ToolbarCommand.Print},
        new ToolbarItemModel() {Command = ToolbarCommand.ImportWord},
    };
    public static readonly List<ToolbarItemModel> PrintTools = new()
    {
        new ToolbarItemModel() {Command = ToolbarCommand.Print},
        new ToolbarItemModel() {Command = ToolbarCommand.ExportPdf},
    };

    public static readonly List<ToolbarItemModel> SimpleTools = new()
    {
        new ToolbarItemModel() {Command = ToolbarCommand.Undo},
        new ToolbarItemModel() {Command = ToolbarCommand.Redo},
        new ToolbarItemModel() {Command = ToolbarCommand.Separator},
        new ToolbarItemModel() {Command = ToolbarCommand.Bold},
        new ToolbarItemModel() {Command = ToolbarCommand.Italic},
        new ToolbarItemModel() {Command = ToolbarCommand.Underline},
        new ToolbarItemModel() {Command = ToolbarCommand.StrikeThrough},
        new ToolbarItemModel() {Command = ToolbarCommand.SuperScript},
        new ToolbarItemModel() {Command = ToolbarCommand.SubScript},
        new ToolbarItemModel() {Command = ToolbarCommand.Separator},
        new ToolbarItemModel() {Command = ToolbarCommand.FontName},
        new ToolbarItemModel() {Command = ToolbarCommand.FontSize},
        new ToolbarItemModel() {Command = ToolbarCommand.FontColor},
        new ToolbarItemModel() {Command = ToolbarCommand.BackgroundColor},
        new ToolbarItemModel() {Command = ToolbarCommand.Separator},
        new ToolbarItemModel() {Command = ToolbarCommand.LowerCase},
        new ToolbarItemModel() {Command = ToolbarCommand.UpperCase},
        new ToolbarItemModel() {Command = ToolbarCommand.Separator},
        new ToolbarItemModel() {Command = ToolbarCommand.Formats},
        new ToolbarItemModel() {Command = ToolbarCommand.Alignments},
        new ToolbarItemModel() {Command = ToolbarCommand.Blockquote},
        new ToolbarItemModel() {Command = ToolbarCommand.Separator},
        new ToolbarItemModel() {Command = ToolbarCommand.NumberFormatList},
        new ToolbarItemModel() {Command = ToolbarCommand.BulletFormatList},
        new ToolbarItemModel() {Command = ToolbarCommand.Separator},
        new ToolbarItemModel() {Command = ToolbarCommand.Outdent},
        new ToolbarItemModel() {Command = ToolbarCommand.Indent},
        new ToolbarItemModel() {Command = ToolbarCommand.Separator},
    };

    public static readonly List<ToolbarItemModel> Tools = new()
    {
        new ToolbarItemModel() {Command = ToolbarCommand.Undo},
        new ToolbarItemModel() {Command = ToolbarCommand.Redo},
        new ToolbarItemModel() {Command = ToolbarCommand.Separator},
        new ToolbarItemModel() {Command = ToolbarCommand.ImportWord},
        // new ToolbarItemModel() {Command = ToolbarCommand.ExportWord},
        new ToolbarItemModel() {Command = ToolbarCommand.Separator},
        new ToolbarItemModel() {Command = ToolbarCommand.Bold},
        new ToolbarItemModel() {Command = ToolbarCommand.Italic},
        new ToolbarItemModel() {Command = ToolbarCommand.Underline},
        new ToolbarItemModel() {Command = ToolbarCommand.StrikeThrough},
        new ToolbarItemModel() {Command = ToolbarCommand.SuperScript},
        new ToolbarItemModel() {Command = ToolbarCommand.SubScript},
        new ToolbarItemModel() {Command = ToolbarCommand.Separator},
        new ToolbarItemModel() {Command = ToolbarCommand.FontName},
        new ToolbarItemModel() {Command = ToolbarCommand.FontSize},
        new ToolbarItemModel() {Command = ToolbarCommand.FontColor},
        new ToolbarItemModel() {Command = ToolbarCommand.BackgroundColor},
        new ToolbarItemModel() {Command = ToolbarCommand.Separator},
        new ToolbarItemModel() {Command = ToolbarCommand.LowerCase},
        new ToolbarItemModel() {Command = ToolbarCommand.UpperCase},
        new ToolbarItemModel() {Command = ToolbarCommand.Separator},
        new ToolbarItemModel() {Command = ToolbarCommand.Formats},
        new ToolbarItemModel() {Command = ToolbarCommand.Alignments},
        new ToolbarItemModel() {Command = ToolbarCommand.Blockquote},
        new ToolbarItemModel() {Command = ToolbarCommand.Separator},
        new ToolbarItemModel() {Command = ToolbarCommand.NumberFormatList},
        new ToolbarItemModel() {Command = ToolbarCommand.BulletFormatList},
        new ToolbarItemModel() {Command = ToolbarCommand.Separator},
        new ToolbarItemModel() {Command = ToolbarCommand.Outdent},
        new ToolbarItemModel() {Command = ToolbarCommand.Indent},
        new ToolbarItemModel() {Command = ToolbarCommand.Separator},
        new ToolbarItemModel() {Command = ToolbarCommand.CreateLink},
        new ToolbarItemModel() {Command = ToolbarCommand.Image},
        new ToolbarItemModel() {Command = ToolbarCommand.Video},
        new ToolbarItemModel() {Command = ToolbarCommand.Audio},
        new ToolbarItemModel() {Command = ToolbarCommand.CreateTable},
        new ToolbarItemModel() {Command = ToolbarCommand.Separator},
        new ToolbarItemModel() {Command = ToolbarCommand.ClearFormat},
        new ToolbarItemModel() {Command = ToolbarCommand.Print},
        new ToolbarItemModel() {Command = ToolbarCommand.SourceCode},
        new ToolbarItemModel() {Command = ToolbarCommand.FullScreen},
    };

    public static readonly List<TableToolbarItemModel> TableQuickToolbarItems = new()
    {
        new TableToolbarItemModel() {Command = TableToolbarCommand.TableHeader},
        new TableToolbarItemModel() {Command = TableToolbarCommand.TableRows},
        new TableToolbarItemModel() {Command = TableToolbarCommand.TableColumns},
        new TableToolbarItemModel() {Command = TableToolbarCommand.TableCell},
        new TableToolbarItemModel() {Command = TableToolbarCommand.HorizontalSeparator},
        new TableToolbarItemModel() {Command = TableToolbarCommand.BackgroundColor},
        new TableToolbarItemModel() {Command = TableToolbarCommand.TableRemove},
        new TableToolbarItemModel() {Command = TableToolbarCommand.TableCellVerticalAlign},
        new TableToolbarItemModel() {Command = TableToolbarCommand.Styles}
    };
}