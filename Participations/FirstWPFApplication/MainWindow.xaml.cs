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

namespace FirstWPFApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            DateTime dob = Convert.ToDateTime(txtDob.Text);

            Student student = new Student();
            student.Name = name;
            student.Birthdate = dob;

            students.Add(student);

            MessageBox.Show($"{student.Name} who is {student.CalculateAge().ToString("N0")} created successfully.");

        }

        private void btnAddStudent_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Background = Brushes.Green;
        }

        private void btnAddStudent_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Background = Brushes.Red;
        }
    }
}
