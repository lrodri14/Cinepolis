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
	public partial class CarteleraPage : ContentPage
    {
        public List<CarouselItem> CarouselItems { get; set; }
        public CarteleraPage()
        {
            InitializeComponent();
            // Aquí creas una lista de CarouselItem con las imágenes y nombres que desees mostrar
            CarouselItems = new List<CarouselItem>
            {
                new CarouselItem { ImageSource = ImageSource.FromFile("barbie.png"), Name = "Barbie" },
                new CarouselItem { ImageSource = ImageSource.FromFile("Flash.jpg"), Name = "Flash" },
                new CarouselItem { ImageSource = ImageSource.FromFile("Transformers.jpg"), Name = "Transformers" },
                // Agrega más elementos si deseas mostrar más imágenes en el carrusel
            };

            // Establece el contexto de enlace de datos para la página
            BindingContext = this;

        }
    }
}