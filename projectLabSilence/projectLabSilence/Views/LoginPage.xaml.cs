namespace projectLabSilence.Views;


public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnSignInClicked(object sender, EventArgs e)
    {
        string enteredUsername = usernameEntry.Text;
        string enteredPassword = passwordEntry.Text;

        // Check against hardcoded admin credentials
        if (enteredUsername == "admin" && enteredPassword == "admin")
        {
            // Navigate to the admin area or dashboard
            await Shell.Current.GoToAsync(nameof(MapPage));
        }
        else
        {
            // Handle incorrect login attempt
            // Show an error message to the user
        }
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///SignUpPage");
    }

}
