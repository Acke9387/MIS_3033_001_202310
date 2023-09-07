﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonExample
{
    public class Person
    {
        public int id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string email { get; set; }
        public string gender { get; set; }

        // skip ip_address

        public string city { get; set; }

        public Person()
        {
            // empty constructor
            first_name = string.Empty;
            last_name = string.Empty;
            email = string.Empty;
            gender = string.Empty;
            city = string.Empty;
        }

        public override string ToString()
        {
            return $"{first_name} {last_name} {city}";
        }
    }
}
