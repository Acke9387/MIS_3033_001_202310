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

namespace FirstWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //MessageBox.Show("Hello, the application is now loaded!");  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userInput = txtFirstNumber.Text;

            userInput = userInput.Replace(" ", "");

            double num1;
            
            if (double.TryParse(userInput, out num1) == false)
            {
                MessageBox.Show($"Sorry, {userInput} is not a number");
                return;
            }
            //MessageBox.Show(num1.ToString("C"));
            lblOutput.Content = num1.ToString("C");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            double left = Convert.ToDouble(txtFirstNumber.Text);
            double right = Convert.ToDouble(txtSecondNumber.Text);

            Equation problem1 = new Equation();
            problem1.Left = left;
            problem1.Right = right; 

            double sum = problem1.Add();
            double quotient = problem1.Division();

            MessageBox.Show($"The sum is {sum} and the quotient is {quotient}");

            
        }
    }
}
