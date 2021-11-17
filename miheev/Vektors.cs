using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miheev
{
    class Vektors
    {
        private int x1;
        private int y1;
        private int z1;
        private int x2;
        private int y2;
        private int z2;

        public Vektors(int x1,int y1, int z1, int x2, int y2, int z2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.z1 = z1;
            this.x2 = x2;
            this.y2 = y2;
            this.z2 = z2;
        }
        public int X
        {
            get => x2-x1;
        }
        public int Y
        {
            get => y2 - y1;
        }
        public int Z
        {
            get => z2 - z1;
        }
        public double GetLength()
        {
            double otv = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
            otv = otv < 0 ? (otv * -1):otv;
            return otv;
        }
        static int Multiplication(Vektors v1, Vektors v2) => v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        static public Vektors Addition(Vektors v1, Vektors v2)
        {
            Vektors v3 = new Vektors(v1.x1 + v2.x1, v1.y1 + v2.y1, v1.z1 + v2.z1, v1.x2 + v2.x2, v1.y2 + v2.y2, v1.z2 + v2.z2);
            return v3;
        }
        static public Vektors Subtraction(Vektors v1, Vektors v2)
        {
            Vektors v3 = new Vektors(v1.x1 - v2.x1, v1.y1 - v2.y1, v1.z1 - v2.z1, v1.x2 - v2.x2, v1.y2 - v2.y2, v1.z2 - v2.z2);
            return v3;
        }
        static public double Cos(Vektors v1, Vektors v2) => Vektors.Multiplication(v1, v2) / (v1.GetLength() * v2.GetLength());

        static public double scalarMultiplication(Vektors v1, Vektors v2) => v1.GetLength() * v2.GetLength() * Vektors.Cos(v1, v2);
    }
}
