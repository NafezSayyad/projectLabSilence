using projectLabSilence.ViewModels;

namespace projectLabSilence.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }

}