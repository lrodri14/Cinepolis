using Cinepolis.Views;
using System;
using Xamarin.Forms;

namespace Cinepolis
{
    public partial class SignUpPage : ContentPage
    {

        private bool isPasswordVisible;
        private bool isPasswordVisibleC;

        public string EyeImageSource => isPasswordVisible ? "eyehide.svg" : "eye.svg";
        public string EyeImageSourceC => isPasswordVisibleC ? "eyehide.svg" : "eye.svg";
        public SignUpPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            isPasswordVisible = false;
            isPasswordVisibleC = false;
            BindingContext = this;
        }

        private async void OnSignInLinkClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignInPage());
        }
        private void TogglePasswordVisibility(object sender, EventArgs e)
        {
            // Lógica para alternar la visibilidad de la contraseña
            isPasswordVisible = !isPasswordVisible;
            passwordEntry.IsPassword = !isPasswordVisible;
            OnPropertyChanged(nameof(EyeImageSource));
        }
        private void TogglePasswordVisibilityC(object sender, EventArgs e)
        {
            // Lógica para alternar la visibilidad de la contraseña
            isPasswordVisibleC = !isPasswordVisibleC;
            passwordEntryC.IsPassword = !isPasswordVisibleC;
            OnPropertyChanged(nameof(EyeImageSourceC));
        }

        private async void SendCodeEmailClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CodeSignUpPage());
        }

    }
}