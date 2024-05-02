using projectLabSilence.Views;
using Microsoft.Maui.Controls;
using System.Windows.Input;
namespace projectLabSilence
{
    public partial class AppShell : Shell
    {
        public ICommand OpenSearchMenuCommand { get; }
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            OpenSearchMenuCommand = new Command(OpenSearchMenu);
        }
        async void OpenSearchMenu()
        {
            var latitudeString = await DisplayPromptAsync("Latitude", "Enter Latitude:");
            var longitudeString = await DisplayPromptAsync("Longitude", "Enter Longitude:");
            if (double.TryParse(latitudeString, out double latitude) && double.TryParse(longitudeString, out double longitude))
            {
                // Send message to MapPageViewModel to update location
                MessagingCenter.Send(this, "UpdateLocation", new Location(latitude, longitude));
            }
        }

        void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
        }
    }
}
