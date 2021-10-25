using System;
using System.Collections.Generic;
using System.Numerics;

namespace OOPtest
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator();
        }

        static void Calculator()
        {
            bool itsWork = true;

            while (itsWork)
            {
                Console.Write("Квадратне рiвняння - введiть 1\nКубiчне рiвняння - введiть 2\n");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    Console.WriteLine("ax^2 + bx + c = 0");
                    Console.WriteLine("Введiть значення a, b, c");
                    double a, b, c;
                    Console.Write("a = ");
                    a = Double.Parse(Console.ReadLine());
                    Console.Write("b = ");
                    b = Double.Parse(Console.ReadLine());
                    Console.Write("c = ");
                    c = Double.Parse(Console.ReadLine());

                    Quadratic(a, b, c);
                    Exit(ref itsWork);
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("ax^3 + bx^2 + cx + d = 0");
                    Console.WriteLine("Введiть значення a, b, c, d");
                    double a, b, c, d;
                    Console.Write("a = ");
                    d = Double.Parse(Console.ReadLine());
                    Console.Write("b = ");
                    a = Double.Parse(Console.ReadLine()) / d;
                    Console.Write("c = ");
                    b = Double.Parse(Console.ReadLine()) / d;
                    Console.Write("d = ");
                    c = Double.Parse(Console.ReadLine()) / d;

                    Cubic(a, b, c);
                    Exit(ref itsWork);
                }
                else
                {
                    Console.WriteLine("Неочiкуванний ввiд. Введiть 1 або 2");
                    Calculator();
                }
            }
        }

        static void Quadratic(double a, double b, double c)
        {
            double D = b * b - 4 * a * c;
            double x1, x2;
            switch (D)
            {
                case (> 0):
                    x1 = (-1 * b + Math.Sqrt(D))/(2*a);
                    x2 = (-1 * b - Math.Sqrt(D)) / (2 * a);
                    Console.WriteLine($"x1 = {x1}\nx2 = {x2}");
                    break;
                case (< 0):
                    Console.WriteLine("Коренiв немає");
                    break;
                default:
                    x1 = (-1 * b) / (2 * a);
                    Console.WriteLine($"x1 = x2 = {x1}");
                    break;
            }
        }

        static void Cubic(double a, double b, double c)
        {
            double Q = (Math.Pow(a, 2) - 3 * b) / 9;
            double R = (2 * Math.Pow(a, 3) - 9 * a * b + 27 * c) / 54;
            double S = Q * Q * Q - R * R;
            double fi;

            Console.WriteLine($"{Q} {R} {S}");

            if (S > 0)
            {
                fi = 1 / 3 * Math.Acos(R/Math.Pow(Q, 1/3));
                double x1 = -2 * Math.Pow(Q, 1 / 2) * Math.Cos(fi) - a / 3;
                double x2 = -2 * Math.Pow(Q, 1 / 2) * Math.Cos(fi + 2 / 3 * Math.PI) - a / 3;
                double x3 = -2 * Math.Pow(Q, 1 / 2) * Math.Cos(fi - 2 / 3 * Math.PI) - a / 3;

                Console.WriteLine($"x1 = {x1}\nx2 = {x2}\nx3 = {x3}");

            }
            else if (S < 0)
            {
                double x1;
                Complex x2, x3;

                if (Q > 0)
                {
                    fi = 1 / 3 * Math.Acosh(Math.Abs(R) / Math.Pow(Math.Abs(Q), 1 / 3));
                    x1 = -2 * Math.Sign(R) * Math.Sqrt(Q) * Math.Cosh(fi) - a / 3;
                    x2 = Math.Sign(R) * Math.Sqrt(Q) * Math.Cosh(fi) - a / 3 + Complex.ImaginaryOne * Math.Sqrt(3) * Math.Sqrt(Q) * Math.Sinh(fi);
                    x3 = Math.Sign(R) * Math.Sqrt(Q) * Math.Cosh(fi) - a / 3 - Complex.ImaginaryOne * Math.Sqrt(3) * Math.Sqrt(Q) * Math.Sinh(fi);
                }
                else if (Q < 0)
                {
                    fi = 1 / 3 * Math.Asinh(Math.Abs(R) / Math.Pow(Math.Abs(Q), 1 / 3));
                    x1 = -2 * Math.Sign(R) * Math.Sqrt(Math.Abs(Q)) * Math.Sinh(fi) - a / 3;
                    x2 = Math.Sign(R) * Math.Sqrt(Math.Abs(Q)) * Math.Sinh(fi) - a / 3 + Complex.ImaginaryOne * Math.Sqrt(3) * Math.Sqrt(Math.Abs(Q)) * Math.Cosh(fi);
                    x3 = Math.Sign(R) * Math.Sqrt(Math.Abs(Q)) * Math.Sinh(fi) - a / 3 - Complex.ImaginaryOne * Math.Sqrt(3) * Math.Sqrt(Math.Abs(Q)) * Math.Cosh(fi);
                }
                else
                {
                    x1 = -1 * Math.Pow(c - Math.Pow(a, 3), 1 / 3) - a / 3;
                    x2 = -(a + x1) / 2 + Complex.ImaginaryOne / 2 + Math.Sqrt(Math.Abs((a - 3 * x1) * (a + x1) - 4 * b));
                    x3 = -(a + x1) / 2 + Complex.ImaginaryOne / 2 - Math.Sqrt(Math.Abs((a - 3 * x1) * (a + x1) - 4 * b));
                }
                Console.WriteLine($"x1 = {x1}\nx2 = {x2}\nx3 = {x3}");

            }
            else
            {
                var x1 = -2 * Math.Sign(R) * Math.Sqrt(Q) - a / 3;
                var x2 = Math.Sign(R) * Math.Sqrt(Q) - a / 3;
                Console.WriteLine($"x1 = {x1}\nx2 = {x2}");
            }
        }

        static void Exit(ref bool itsWork)
        {
            Console.WriteLine("Вийти з програми? (Y/N)");
            string userInput = Console.ReadLine().ToUpper();
            if (userInput == "Y")
            {
                itsWork = false;
            }
            else if (userInput == "N")
            {
                itsWork = true;
            }
            else
            {
                Console.WriteLine("Введiть Y або N");
                Exit(ref itsWork);
            }
        }
    }
}
