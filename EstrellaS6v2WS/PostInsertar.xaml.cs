using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstrellaS6v2WS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostInsertar : ContentPage
    {
        public PostInsertar()
        {
            InitializeComponent();
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient client= new WebClient();

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                client.UploadValues("http://172.24.96.1/uisrael2023/post.php", "POST", parametros);
                await DisplayAlert("Alerta", "Ingreso correctamente", "OK");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "ERROR " + ex.Message, "OK");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}