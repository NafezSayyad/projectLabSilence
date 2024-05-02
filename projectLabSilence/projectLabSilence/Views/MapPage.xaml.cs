namespace projectLabSilence.Views;
using Microsoft.Maui.Controls.Maps;
using projectLabSilence.ViewModels;
using CommunityToolkit.Mvvm.Messaging;

public partial class MapPage : ContentPage
{
    public MapPage()
    {
        InitializeComponent();
        // Ensure the ViewModel is assigned as the BindingContext
        this.BindingContext = new MapPageViewModel();
        map.MapClicked+=OnMapClicked;

        // Subscribe to ViewModel messages for region updates
        WeakReferenceMessenger.Default.Register<UpdateMapRegionMessage>(this, (recipient, message) =>
        {
            map.MoveToRegion(message.Region);
        });
    }

    private void OnMapClicked(object sender, MapClickedEventArgs e)
    {
        // Convert Location to a format suitable for the ViewModel command
        var viewModel = this.BindingContext as MapPageViewModel;
        viewModel?.MapClickedCommand.Execute(new Location(e.Location.Latitude, e.Location.Longitude));

    }

    private void Pins_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        // This method is called when the Pins collection in the ViewModel changes
        // It updates the UI map pins to reflect the current state of the ViewModel
        if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
        {
            foreach (Pin pin in e.NewItems)
            {
                map.Pins.Add(pin);
            }
        }
        else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
        {
            foreach (Pin pin in e.OldItems)
            {
                map.Pins.Remove(pin);
            }
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Subscribe to Pins collection changes
        var viewModel = BindingContext as MapPageViewModel;
        if (viewModel != null)
        {
            viewModel.Pins.CollectionChanged += Pins_CollectionChanged;
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        // Unsubscribe from ViewModel messages and collection changes to avoid memory leaks
        WeakReferenceMessenger.Default.Unregister<UpdateMapRegionMessage>(this);

        var viewModel = BindingContext as MapPageViewModel;
        if (viewModel != null)
        {
            viewModel.Pins.CollectionChanged -= Pins_CollectionChanged;
        }
    }
}

