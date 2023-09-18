using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WebRequest_RickAndMorty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string url = @"https://rickandmortyapi.com/api/character";


            HttpClient client = new HttpClient();

            string json = client.GetStringAsync(url).Result;

            RickAndMortyAPI api;

            api = JsonConvert.DeserializeObject<RickAndMortyAPI>(json);

            foreach (Result character in api.results)
            {
                cboCharacters.Items.Add(character);
            }
         
        }

        private void cboCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCharacter = (Result) cboCharacters.SelectedItem;

            txtName.Text = selectedCharacter.name;

            imgCharacter.Source = new BitmapImage(new Uri(selectedCharacter.image));
        }
    }
}
