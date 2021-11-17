using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miheev
{
    class Array
    {
        private int[] mas;
        public Array(uint count)
        {
            mas = new int[count];
        }
        public void MultiplicationOnNumb(int num)
        {
            for (int i=0;i<mas.Length;i++)
            {
                mas[i] *= num;
            }
        }
        public int GetElement(int index)
        {
            if (index>=mas.Length ) return mas[mas.Length - 1];
            else
            {
                if (index < 0) return mas[0];
                else
                {
                    return mas[index];
                }
            }
        }
        private int[] GetMas() => mas;
        public void SetMas(int[] arr) => mas = arr;
        public string ForPrint()
        {
            string[] a = new string[mas.Length];
            for(int i=0;i<mas.Length;i++)
            {
                    a[i] = mas[i].ToString();
            }
            return string.Join(" ", a);
        }
        public void AddElement(int num, int index)
        {
            if (index >= mas.Length)  mas[mas.Length - 1]=num;
            else
            {
                if (index < 0) mas[0]=num;
                else
                {
                    mas[index]=num;
                }
            }
        }
        static public int[] AdditionArrays(Array mas1, Array mas2)
        {
            int minLength=mas1.GetMas().Length;
            if (mas1.GetMas().Length > mas2.GetMas().Length) minLength = mas2.GetMas().Length;
            int[] mas3 = new int[minLength];
            for (int i=0;i<minLength;i++)
            {
                mas3[i] = mas1.GetMas()[i] + mas2.GetMas()[i];
            }
            return mas3;
        }
        static public int[] SubtractionArrays(Array mas1, Array mas2)
        {
            int minLength = mas1.GetMas().Length;
            if (mas1.GetMas().Length > mas2.GetMas().Length) minLength = mas2.GetMas().Length;
            int[] mas3 = new int[minLength];
            for (int i = 0; i < minLength; i++)
            {
                mas3[i] = mas1.GetMas()[i] - mas2.GetMas()[i];
            }
            return mas3;
        }
    }
}
