using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinepolis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePasswordPage : ContentPage

    {
        private bool isPasswordVisible;
        public string EyeImageSource => isPasswordVisible ? "eyehide.svg" : "eye.svg"; //


        public ChangePasswordPage()
        {
            InitializeComponent();
            isPasswordVisible = false; //
        }

        private void TogglePasswordVisibility(object sender, EventArgs e) //
        {
            // Lógica para alternar la visibilidad de la contraseña
            isPasswordVisible = !isPasswordVisible;
            passwordEntry.IsPassword = !isPasswordVisible;
            OnPropertyChanged(nameof(EyeImageSource));
        }

        
        private void TogglePasswordVisibility2(object sender, EventArgs e) //
        {
            // Lógica para alternar la visibilidad de la contraseña
            isPasswordVisible = !isPasswordVisible;
            passwordEntry2.IsPassword = !isPasswordVisible;
            OnPropertyChanged(nameof(EyeImageSource));
        }

        


        private async void ChangePasswordClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignInPage());

        }
    }
}