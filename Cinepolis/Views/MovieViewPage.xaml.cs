using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinepolis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieViewPage : ContentPage
    {


        public MovieViewPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            // Obtener los datos del horario y sala desde la base de datos
            string horario = ObtenerHorarioDesdeBD();
            string sala = ObtenerSalaDesdeBD();

            // Establecer el texto de los Labels de Horario y Sala con los datos obtenidos
            HorarioLabel.Text = horario;
            SalaLabel.Text = sala;

        }


        private string ObtenerHorarioDesdeBD()
        {
            // Aquí debes implementar el código para obtener el horario desde la base de datos
            // Retorna el valor del horario como una cadena de texto
            return "3:00 PM";
        }

        private string ObtenerSalaDesdeBD()
        {
            // Aquí debes implementar el código para obtener la sala desde la base de datos
            // Retorna el valor de la sala como una cadena de texto
            return "Sala 1";
        }

        private void OnSeleccionarClicked(object sender, EventArgs e)
        {
            // Aquí puedes manejar la lógica cuando se hace clic en el botón "Seleccionar"
        }
    }
}