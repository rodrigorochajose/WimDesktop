namespace DMMDigital.Views
{
    public interface IDialogGenerateTemplateView
    {
        string templateName { get; set; }
        int rows { get; set; }
        int columns { get; set; }
        string orientation { get; set; }
    }
}
