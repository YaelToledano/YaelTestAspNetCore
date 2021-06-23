using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YaelTestWebApi.Models
{
    public class Calculator
    {
        public int id { get; set; }
        public int num1 { get; set; }
        public string _operator { get; set; }
        public int num2 { get; set; }
        public int result { get; set; }

    }
}
