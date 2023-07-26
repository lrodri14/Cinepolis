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
        private bool isPasswordVisibleC;

        public string EyeImageSource => isPasswordVisible ? "eyehide.svg" : "eye.svg";
        public string EyeImageSourceC => isPasswordVisibleC ? "eyehide.svg" : "eye.svg";


        public ChangePasswordPage()
        {
            InitializeComponent();
            isPasswordVisible = false;
            isPasswordVisibleC = false;
            BindingContext = this;
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


        private async void ChangePasswordClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignInPage());

        }
    }
}