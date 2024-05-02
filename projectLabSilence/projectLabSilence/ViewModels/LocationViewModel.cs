
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using projectLabSilence.Models;

namespace projectLabSilence.ViewModels
{
    internal partial class LocationViewModel : ObservableObject
    {
        [ObservableProperty]
        private Location _currentLocation;

        [ObservableProperty]
        private ObservableCollection<Place> _places;
        private RelayCommand CheckLocationCommand;

        public LocationViewModel()
        {
            Places = new ObservableCollection<Place>();
            CheckLocationCommand = new RelayCommand(async () => await CheckCurrentLocationAsync());
        }

        [RelayCommand]
        public async Task CheckCurrentLocationAsync()
        {
            CurrentLocation = await GetCurrentLocationAsync();
            CheckGeofences();
        }

        private async Task<Location> GetCurrentLocationAsync()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                    return location;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error getting location: {ex}");
            }
            return null;
        }

        private void CheckGeofences()
        {
            foreach (var place in Places)
            {
                if (IsWithinGeofence(CurrentLocation, place))
                {
                    // Trigger actions like silent mode or notifications
                    TriggerActionForGeofenceEntry(place);
                }
            }
        }

        private bool IsWithinGeofence(Location currentLocation, Place place)
        {
            // Placeholder for actual geofence checking logic
            var distance = Location.CalculateDistance(currentLocation, new Location(place.Latitude, place.Longitude), DistanceUnits.Kilometers);
            return distance <= place.Radius;
        }

        private void TriggerActionForGeofenceEntry(Place place)
        {
            Console.WriteLine($"Entered geofence at {place.Name}");
            // Further implementation needed
        }
    }
}
