
namespace Dexterity
{
    public partial class MainPage : ContentPage
    {
        public MainPage( string startPath = null)
        {
            InitializeComponent();
            
            if (startPath != null)
            {
                blazorWebView.RootComponents[0].Parameters = new Dictionary<string, object>
                {
                    { "StartPath", startPath },

                };
            }
        }

    }
}