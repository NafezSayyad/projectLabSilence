using Microsoft.Maui.Controls.Maps;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.Http;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Maps;

namespace projectLabSilence.ViewModels
{
    [ObservableObject]
    public partial class MapPageViewModel
    {
        [ObservableProperty]
        private ObservableCollection<Pin> pins = new();

        [ObservableProperty]
        private ObservableCollection<MapElement> mapElements = new();

        [ObservableProperty]
        private double circleRadius = 1000;




        public MapPageViewModel()
        {
            // Subscribe to messages for updating the location
            MessagingCenter.Subscribe<AppShell, Location>(this, "UpdateLocation", (sender, location) =>
            {
                MoveToLocation(location);
            });
        }

        [RelayCommand]
        async Task PerformSearch(string query)
        {
            var coordinates = await GeocodingService.GetCoordinatesFromQuery(query);
            if (coordinates.HasValue)
            {
                var (Latitude, Longitude) = coordinates.Value;
                var location = new Location(Latitude, Longitude);
                var mapSpan = MapSpan.FromCenterAndRadius(location, Distance.FromMiles(1));

                Pins.Clear();
                Pins.Add(new Pin
                {
                    Label = query,
                    Location = location
                });

                MoveToRegion(mapSpan);
            }
        }

        [RelayCommand]
        private void OnMapClicked(Location location)
        {
            Pins.Clear();
            MapElements.Clear();

            Pins.Add(new Pin
            {
                Label = "Selected Location",
                Location = location
            });

            MapElements.Add(new Circle
            {
                Center = location,
                Radius = new Distance(CircleRadius)
            });
        }

        private void MoveToLocation(Location location)
        {
            var mapSpan = MapSpan.FromCenterAndRadius(location, Distance.FromMiles(1));
            Pins.Clear();
            Pins.Add(new Pin
            {
                Label = "Searched Location",
                Location = location
            });
            MoveToRegion(mapSpan);
        }

        private void UpdateCircleRadius()
        {
            if (MapElements.FirstOrDefault() is Circle circle)
            {
                circle.Radius = new Distance(CircleRadius);
            }
        }

        private void MoveToRegion(MapSpan region)
        {
            WeakReferenceMessenger.Default.Send(new UpdateMapRegionMessage(region));
        }
    }

    public record UpdateMapRegionMessage(MapSpan Region);

    public static class GeocodingService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string ApiKey = "AIzaSyBIf5_GPBID3bqRvOl4Qc-_PqgGJZ_CX68"; //secure this later
        public static async Task<(double Latitude, double Longitude)?> GetCoordinatesFromQuery(string query)
        {
            try
            {
                var requestUri = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(query)}&key={ApiKey}";
                var response = await httpClient.GetStringAsync(requestUri);
                var jsonDocument = JsonDocument.Parse(response);

                var locationElement = jsonDocument.RootElement
                                                   .GetProperty("results")[0]
                                                   .GetProperty("geometry")
                                                   .GetProperty("location");
                var latitude = locationElement.GetProperty("lat").GetDouble();
                var longitude = locationElement.GetProperty("lng").GetDouble();

                return (latitude, longitude);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching geocoding data: {ex.Message}");
                return null;
            }
        }
    }
}
