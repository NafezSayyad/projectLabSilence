using System;
using Microsoft.Maui.Controls;
namespace projectLabSilence.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
	}
    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        // Implement your sign-up logic here
        // For example: Validate inputs, create user account, etc.
    }

    private async void OnLogInClicked(object sender, EventArgs e)
    {
        // Navigate back to the login page
        await Shell.Current.GoToAsync("//LoginPage");
    }
}