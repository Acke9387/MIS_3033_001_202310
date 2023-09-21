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

namespace Json_ChuckNorrisJokes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string url = @"https://api.chucknorris.io/jokes/categories";
            cboCategory.Items.Add("All");
            cboCategory.SelectedIndex = 0;

            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync(url).Result;
                var categories = JsonConvert.DeserializeObject<List<string>>(json);

                foreach (var category in categories)
                {
                    cboCategory.Items.Add(category);
                }

            }

        }

        /// <summary>
        /// https://json2csharp.com/ generates our C# classes from the JSON
        /// </summary>
        private void btnGetJoke_Click(object sender, RoutedEventArgs e)
        {

            string url = @"https://api.chucknorris.io/jokes/random";
            string category = cboCategory.SelectedItem.ToString();

            if (category != "All")
            {
                url = $"https://api.chucknorris.io/jokes/random?category={category}";
            }

            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync(url).Result;
                
                var joke = JsonConvert.DeserializeObject<ChuckNorrisApi>(json);

                txtJoke.Text = joke.value;

            }

        }
    }
}
