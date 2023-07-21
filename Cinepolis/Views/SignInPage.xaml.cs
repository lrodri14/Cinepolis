using Cinepolis.Views;
using System;
using Xamarin.Forms;


namespace Cinepolis
{
    public partial class SignInPage : ContentPage
    {
        private bool isPasswordVisible; //

        public string EyeImageSource => isPasswordVisible ? "eyehide.svg" : "eye.svg"; //


        public SignInPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            isPasswordVisible = false; //
            BindingContext = this;

        }

        private async void OnSignUpLinkClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        private async void ForgotPasswordClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPasswordPage());
        }

        private void TogglePasswordVisibility(object sender, EventArgs e) //
        {
            // Lógica para alternar la visibilidad de la contraseña
            isPasswordVisible = !isPasswordVisible;
            passwordEntry.IsPassword = !isPasswordVisible;
            OnPropertyChanged(nameof(EyeImageSource));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}
