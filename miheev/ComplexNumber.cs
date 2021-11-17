using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miheev
{
    class ComplexNumber
    {
        private int num1;
        private int num2;
        public int Num1
        {
            get  => num1;
            set => num1 = value;
        }
        public int Num2
        {
            get => num2;
            set => num2 = value;
        }
        public int Addition() => num1 + num2;
        public int Subtraction() => num1 - num2;
        public int Multiplication() => (num1 * num2) * -1;
    }
}
