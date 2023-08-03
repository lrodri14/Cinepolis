using Cinepolis.ModelViews;
using Cinepolis.Views;
using System;
using Xamarin.Forms;

namespace Cinepolis.Views
{
    public partial class DatosPersonales : ContentPage
    {
        private Datos datos; // Instancia de la clase Datos

        public DatosPersonales()
        {
            InitializeComponent();

            // Crear e inicializar la instancia de la clase Datos
            datos = new Datos
            {
                Pelicula = "Barbie",
                ciudad = "San Pedro Sula",
                fecha = "Jueves, 27/07/2023",
                hora = "5:00 PM",
                sala = 3,
                asientos = "A1, A2, A3",
                nombre = "Ana Julia",
                apellidos = "Romero Díaz",
                correo = "ana.romero@gmail.com",
                ImagenProducto = "barbie.png", // Si es una imagen local
                total = 100.50 // El total en IVA (por ejemplo)
            };

            BindingContext = datos; // Establecer la instancia como contexto de enlace
        }


        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void BOnSiguienteButtonClicked(object sender, EventArgs e)
        {

        }
    }
}
