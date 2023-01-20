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
	public partial class Delete : ContentPage
	{
		public Delete ()
		{
			InitializeComponent ();
		}

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                const string uri = "http://192.168.100.10/uisrael2023/post.php";

                WebClient client= new WebClient ();
                string parametros = "?codigo=" + txtCodigo.Text;
                var urlPost = new Uri (uri + parametros);

                client.UploadStringAsync(urlPost, "DELETE", "");
                DisplayAlert("Mensaje de Alerta", "Registro Eliminado", "OK");

            }
            catch(Exception ex)
            {
                await DisplayAlert("Alerta", "ERROR" + ex.Message, "OK");
            }

        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}