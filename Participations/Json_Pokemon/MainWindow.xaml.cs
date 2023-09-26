using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Json_Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Pokemon pokeDetails = null;
        private bool showFront = true;

        public MainWindow()
        {
            InitializeComponent();

            string url = @"https://pokeapi.co/api/v2/pokemon/?offset=00&limit=1300";

            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(url).Result;
                var cbopokemen = JsonConvert.DeserializeObject<PokemonAPI>(response);

                foreach (var item in cbopokemen.results)
                {
                    cboPokemen.Items.Add(item);
                }
            }

        }

        private void cboPokemen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PokemonItem selectedPokemon = (PokemonItem)cboPokemen.SelectedItem;

            if (selectedPokemon == null) { return; }

            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(selectedPokemon.url).Result;
                pokeDetails = JsonConvert.DeserializeObject<Pokemon>(response);

                txtHeight.Text = pokeDetails.height.ToString();
                txtName.Text = pokeDetails.name;
                txtWeight.Text = pokeDetails.weight.ToString();
                imgPoke.Source = new BitmapImage(new Uri(pokeDetails.sprites.front_default));
                showFront = false;
            }
            btnRotate.IsEnabled = true;
        }

        private void btnRotate_Click(object sender, RoutedEventArgs e)
        {
            if (pokeDetails != null)
            {
                if (showFront == false)
                {
                    imgPoke.Source = new BitmapImage(new Uri(pokeDetails.sprites.back_default));

                }
                else
                {
                    imgPoke.Source = new BitmapImage(new Uri(pokeDetails.sprites.front_default));

                }
                showFront = !showFront;

            }
        }
    }
}
