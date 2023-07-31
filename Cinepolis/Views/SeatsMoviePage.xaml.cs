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
	public partial class SeatsMoviePage : ContentPage
	{
        private List<string> asientosSeleccionados = new List<string>();

        public SeatsMoviePage ()
		{
			InitializeComponent ();
		}


        private void OnSeatClicked(object sender, EventArgs e)
        {
            // Obtener el botón que activó el evento
            var button = (Button)sender;
            string seatNumber = button.Text;

            if (button.BackgroundColor == Color.Red)
            {
                DisplayAlert("Asiento ocupado", "Seleccione otro asiento, este ya ha sido ocupado.", "Aceptar");
                return;
            }

            // Cambiar el color del botón a naranja (#FFA500) si está azul (#3b5998)
            if (button.BackgroundColor == Color.FromHex("#3b5998"))
            {
                if (!asientosSeleccionados.Contains(seatNumber))
                {
                    // Si el asiento no está en el arreglo, lo agregamos
                    asientosSeleccionados.Add(seatNumber);
                }
                button.BackgroundColor = Color.FromHex("#FFA500");
            }
            else // Restaurar el color original si está naranja
            {
                button.BackgroundColor = Color.FromHex("#3b5998");
                // Si el botón está en color naranja (#FFA500)
                if (asientosSeleccionados.Contains(seatNumber))
                {
                    // Si el asiento está en el arreglo, lo eliminamos (se deselecciona)
                    asientosSeleccionados.Remove(seatNumber);
                }
            }


            // Actualizamos el contenido del label con los asientos seleccionados
            asientosArreglo.Text = string.Join(", ", asientosSeleccionados);



        }

    }

}