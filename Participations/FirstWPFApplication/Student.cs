using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWPFApplication
{
    public class Student
    {

        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }

        /// <summary>
        /// Default empty constructor
        /// </summary>
        public Student()
        {
            Name =  string.Empty;
            Birthdate = null;
        }

        /// <summary>
        /// Calculates the age of the student
        /// </summary>
        /// <returns>The age of the student as a whole number</returns>
        public int CalculateAge()
        {
            if (Birthdate.HasValue)
            {
                DateTime today = DateTime.Today;
                int age = today.Year - Birthdate.Value.Year;
                if (Birthdate.Value > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
            else
            {
                return -1;
            }
        }


        public override string ToString()
        {
            return $"{Name} was born on {Birthdate?.ToShortDateString()}";
        }
    }
}
