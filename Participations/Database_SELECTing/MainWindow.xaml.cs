using Database_SELECTing.Models;
using Microsoft.EntityFrameworkCore;
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

namespace Database_SELECTing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DB_128040_practiceContext db = new DB_128040_practiceContext();
        public MainWindow()
        {
            InitializeComponent();

            using (var db = new DB_128040_practiceContext())
            {
                foreach (var student in db.Students)
                {
                    lstStudents.Items.Add(student);
                }

                foreach (var course in db.Courses)
                {
                    lstCourses.Items.Add(course);
                }

            }

        }

        private void lstStudents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedStudent = (Student)lstStudents.SelectedItem;

            MessageBox.Show($"{selectedStudent.FirstName} {selectedStudent.LastName} has a favorite color of {selectedStudent.FavoriteColor}");// is enrolled in the following courses:");

        }

        private void lstCourses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedCourse = (Course)lstCourses.SelectedItem;

            MessageBox.Show($"{selectedCourse.CourseName} ({selectedCourse.CourseNumber}) is a {selectedCourse.TermCode} course.");

        }

        private void lstStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedStudent = (Student)lstStudents.SelectedItem;


            using (var db = new DB_128040_practiceContext())
            {
                Student? s = db.Students.Find(selectedStudent.StudentId);

                //var studentsWhoLikeBlue = db.Students.Where(stud => stud.FavoriteColor.ToLower().Contains("blue")
                //                                            || stud.FavoriteColor.ToLower().Contains("pink")).ToList();

                //List<Registration> registrations1 = new List<Registration>();

                //foreach (var r in db.Registrations)
                //{
                //    if(r.StudentId == selectedStudent.StudentId)
                //    {
                //          registrations1.Add(r);
                //    }
                //}

                var registrations = db.Registrations.Include(o => o.Student).Include(o => o.Course).Where(r => r.StudentId == selectedStudent.StudentId).ToList();

                lstRegistrations.Items.Clear();
                foreach (var register in registrations)
                {
                    lstRegistrations.Items.Add(register);
                }

            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new DB_128040_practiceContext())
            {

                Student newStudent = new Student();
                newStudent.FirstName = "Boone";
                newStudent.LastName = "Todd";
                newStudent.FavoriteColor = "Purple";

                db.Students.Add(newStudent);

                db.SaveChanges();
            }


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = (Student)lstStudents.SelectedItem;

            using (var db = new DB_128040_practiceContext())
            {
                List<Student> studs = db.Students.Where(s => s.FavoriteColor == "Purple").ToList();

                foreach (var item in studs)
                {
                    db.Students.Remove(item);
                }

                db.Students.RemoveRange(studs);

                db.SaveChanges();
            }
        }

        private void btnRegisterForCourse_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = (Student)lstStudents.SelectedItem;
            var selectedCourse = (Course)lstCourses.SelectedItem;


            using (var db = new DB_128040_practiceContext())
            {
                Registration r = new Registration();
                r.StudentId = selectedStudent.StudentId;
                r.CourseId = selectedCourse.CourseId;
                r.EnrollmentDate = DateTime.Now;

                db.Registrations.Add(r);

                db.SaveChanges();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = (Student)lstStudents.SelectedItem;


            using (var db = new DB_128040_practiceContext())
            {
                Student? s = db.Students.Find(selectedStudent.StudentId);

                s.FirstName = "Joe";

                db.SaveChanges();
            }
        }
    }
}
