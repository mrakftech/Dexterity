using Services.DbInitaiizer;

namespace Dexterity
{
    public partial class App : Application
    {
        public App(IDatabaseSeeder seeder)
        {
            InitializeComponent();
            seeder.Initialize();
            MainPage = new MainPage();
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
            if (window != null)
            {
                window.Title = "Dexterity";
            }

            return window;
        }
    }
    
}