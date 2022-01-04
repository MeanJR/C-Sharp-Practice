using System;

namespace GradeCalculate
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = int.Parse(Console.ReadLine());
            String grade = (score >= 80) ? "A" :
                           (score >= 70) ? "B" :
                           (score >= 60) ? "C" :
                           (score >= 50) ? "D" :
                                           "F" ;
            Console.WriteLine(grade);
        }
    }
}
