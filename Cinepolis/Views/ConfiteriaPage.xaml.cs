
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


using System.Collections.Generic;
using System;
using Cinepolis.ModelViews;
using Cinepolis.Views;
using Rg.Plugins.Popup.Services;


namespace Cinepolis.Views
{

    public partial class ConfiteriaPage : ContentPage
    {

        public List<Golosina> ConfiteriaList { get; set; }

        // Nueva propiedad para el total a pagar
        private double total;
        public double Total
        {
            get { return total; }
            set
            {
                if (total != value)
                {
                    total = value;
                    OnPropertyChanged(nameof(Total));
                }
            }
        }

        public ConfiteriaPage()
        {
            InitializeComponent();

            ConfiteriaList = new List<Golosina>
            {
                new Golosina
                {
                    NombreProducto = "Combo 1",
                    ImagenProducto = "combo1.jpg",
                    Descripcion = "Palomitas de Maiz + 2 Refrescos",
                    Precio = 120,
                    Cantidad = 0,
                },
                new Golosina
                {
                    NombreProducto = "Combo 2",
                    ImagenProducto = "combo2.jpg",
                    Descripcion = "Palomitas de Maiz + 1 Refresco",
                    Precio = 95,
                    Cantidad = 0,
                },
                // Agregar aquí los demás productos definidos previamente...
            };

            // Suscribir al evento CantidadChanged para cada objeto Golosina
            foreach (var producto in ConfiteriaList)
            {
                producto.PropertyChanged += CantidadChanged;
            }

            UpdateTotal(); // Calcular el total al inicio
            BindingContext = this;
        }

        // Método para actualizar el total cada vez que cambie la cantidad de un producto
        private void UpdateTotal()
        {
            double total = 0;
            foreach (var producto in ConfiteriaList)
            {
                total += producto.Total;
            }
            Total = total;
        }

        // Evento que se dispara cuando cambia la cantidad de un producto
        private void CantidadChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Golosina.Cantidad))
            {
                UpdateTotal(); // Actualizar el total cuando cambie la cantidad de un producto
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DatosPersonales());
        }

        private async void CarritoIcon_Clicked(object sender, EventArgs e)
        {
            // Llama al constructor de la ventana emergente y pásale la lista de productos
            var detalleFacturaPopup = new DetalleFactura(ConfiteriaList);

            // Muestra la ventana emergente
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(detalleFacturaPopup);
        }

    }

}