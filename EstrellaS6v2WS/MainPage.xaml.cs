using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace EstrellaS6v2WS
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.100.10/uisrael2023/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<EstrellaS6v2WS.WS.Datos> _post;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<EstrellaS6v2WS.WS.Datos> posts = JsonConvert.DeserializeObject<List<EstrellaS6v2WS.WS.Datos>>(content);
            _post = new ObservableCollection<EstrellaS6v2WS.WS.Datos>(posts);

            MyListView.ItemsSource = _post;
        }

        private async void btnPost_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PostInsertar());
        }


        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Delete());
        }

        private async void btnPut_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Put());
        }
    }
}
