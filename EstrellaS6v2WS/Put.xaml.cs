using EstrellaS6v2WS.WS;
using Newtonsoft.Json;
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
	public partial class Put : ContentPage
	{
		public Put ()
		{
			InitializeComponent ();
		}

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                const string uri = "http://192.168.100.10/uisrael/post.php";
                WebClient client= new WebClient ();

                Datos data = new Datos();
                data.codigo = int.Parse(txtCodigo.Text);
                data.nombre = txtNombre.Text;
                data.apellido= txtApellido.Text;
                data.edad = int.Parse(txtEdad.Text);
                var content = JsonConvert.SerializeObject(data);

                var parametros = "";
                parametros = "?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text;
                var urlPost = new Uri(uri + parametros);

                client.UploadString(urlPost, "PUT", content);
                DisplayAlert("Mensaje de Alerta", "Registro Actualizado Correctamente", "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "ERROR " + ex.Message, "ok");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}