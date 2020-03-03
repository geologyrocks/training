using System;

namespace DemoRefactoring.Refactored
{
    public class Util
    {
        public static String GetGrade(int mark)
        {
            if (mark >= 75)
                return "A*";
            else if (mark >= 70)
                return "A";
            else if (mark >= 60)
                return "B";
            else if (mark >= 50)
                return "C";
            else if (mark >= 40)
                return "D";
            else if (mark >= 30)
                return "E";
            else
                return "U";
        }
    }
}
