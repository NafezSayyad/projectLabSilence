using projectLabSilence.Views;

namespace projectLabSilence
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
