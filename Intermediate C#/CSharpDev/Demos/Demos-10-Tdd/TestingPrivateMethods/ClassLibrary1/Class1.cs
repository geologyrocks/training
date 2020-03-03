using System;

namespace ClassLibrary1
{
    public class Class1
    {
        public int Square(string numStr)
        {
            int num = Parse(numStr);
            return num * num;
        }

        public int Cube(string numStr)
        {
            int num = Parse(numStr);
            return num * num * num;
        }

        private int Parse(string str)
        {
            return int.Parse(str);
        }
    }
}
