using EF_SelectingFromDatabase.Models;
using System;
using System.Collections.Generic;
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

namespace EF_SelectingFromDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            DB_128040_practiceContext db = new DB_128040_practiceContext();

            foreach (FootballSchedule fs in db.FootballSchedules)
            {
                if (fs.IsHomeGame == false)
                {
                    lstAway.Items.Add(fs); 
                }
                else
                {
                    lstHome.Items.Add(fs);
                }
            }
        }
    }
}
