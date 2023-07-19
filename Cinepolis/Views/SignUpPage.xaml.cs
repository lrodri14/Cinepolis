using Xamarin.Forms;

namespace Cinepolis
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = this;
        }

        private async void OnSignInLinkClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignInPage());
        }
    }
}