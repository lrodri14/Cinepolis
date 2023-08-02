using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinepolis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarteleraPage : ContentPage
    {
        public List<CarouselItem> Estrenos { get; set; }
        public List<CarouselItem> Proximamente { get; set; }

        public CarteleraPage()
        {
            InitializeComponent();
            Estrenos = new List<CarouselItem>{};
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadEstrenosFromApi("0");
            BindingContext = this;
        }

        public async Task LoadEstrenosFromApi(string status)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://64.227.10.233/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await httpClient.GetAsync("servicios?estado=" + status);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        dynamic data = JsonConvert.DeserializeObject(jsonResponse);
                        JArray peliculasArray = data?.data?.peliculas;
                        if (peliculasArray != null)
                        {
                            foreach (var item in peliculasArray)
                            {
                                int id = (int)item["id"];
                                string titulo = (string)item["titulo"];
                                string duracion = (string)item["duracion"];
                                string genero = (string)item["genero"];
                                string imagen = "http://64.227.10.233" + (string)item["imagen"];
                                string sinopsis = (string)item["sinopsis"];
                                string actores = (string)item["actores"];
                                int estado = (int)item["estado"];
                                string clasificacion = (string)item["clasificacion"];
                                await DisplayAlert("", $"Id: {id}, Titulo: {titulo}, Duracion: {duracion}, Genero: {genero}", "Ok");


                                CarouselItem carouselItem = new CarouselItem
                                {
                                    Id = id,
                                    Titulo = titulo,
                                    Duracion = duracion,
                                    Genero = genero,
                                    Sinopsis = sinopsis,
                                    Actores = actores,
                                    Estado = estado,
                                    ImageSource = ImageSource.FromUri(new Uri(imagen)),
                                    Clasificacion = clasificacion
                                };
                                Estrenos.Add(carouselItem);
                            }
                            //BindingContext = this;
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "Failed to fetch data from the API", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "An error occurred while fetching data from the API", "OK");
            }
        }
    }
}