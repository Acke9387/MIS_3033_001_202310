
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace JsonExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string fileContentsAsJson = File.ReadAllText("MOCK_DATA.json");
            /*
             [ 
                {
                  "id": 1,
                  "first_name": "Twyla",
                  "last_name": "Dykins",
                  "email": "tdykins0@paginegialle.it",
                  "gender": "Female",
                  "ip_address": "139.162.154.22",
                  "city": "Tshikapa"
                },
            */
            List<Person> people = JsonConvert.DeserializeObject<List<Person>>(fileContentsAsJson) ;

            foreach (Person person in people)
            {
                lstPeople.Items.Add(person);
            }

        }

        private void lstPeople_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Person selectedPerson = (Person)lstPeople.SelectedItem;

            MessageBox.Show($"{selectedPerson.email} , {selectedPerson.gender}");
        }
    }
}
