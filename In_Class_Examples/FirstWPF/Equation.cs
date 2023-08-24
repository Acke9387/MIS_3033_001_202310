using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FirstWPF
{
    public class Equation
    {
        public double Left { get; set; }

        public double Right { get; set; }

        public string name { get; set; }

        /// <summary>
        /// Empty/default constructor
        /// </summary>
        public Equation()
        {
            Left = 0;
            Right = 0;
            name = string.Empty;
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right Operand</param>
        public Equation(double left, double right)
        {
            Left = left;
            Right = right;
            name = string.Empty;
            name = "";
        }

        public double Add()
        {
            double answer = 0;

            answer = Left + Right;
            return answer;
        }

        public double Division()
        {
            double answer = 0;

            if (Right != 0)
            {
                answer = Left / Right; 
            }
            else
            {
                answer = -99999;
            }

            return answer;
        }

    }
}
