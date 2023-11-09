using Plugin.Media;
using tarea1._4.Models;
using tarea1._4.Views;

namespace tarea1._4
{
    public partial class MainPage : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;
        public MainPage()
        {
            InitializeComponent();
           
        }

        public byte[] ImageToArrayByte()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] data = memory.ToArray();

                    return data;
                }
            }
            return null;
        }

        private async void tomarfoto_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "MIALBUN",
                Name = "Foto.jpg",
                SaveToAlbum = true
            });

            if (photo != null)
            {
                Photo.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }

        }

        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            var person = new Models.Fotos
            {
                Imagen = ImageToArrayByte(),
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text

            };

            if (await App.SQLiteBD.SavedFotoAsync(person) > 0)
            {
                await DisplayAlert("Aviso", "Foto agregada", "OK");
            }
            else
            {
                await DisplayAlert("Alerta", "Ocurrio un error", "OK");
            }

        }

        private async void verfotos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageFotos());
        }
    }
}