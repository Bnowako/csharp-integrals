using System;

namespace integration
{

    public static class Globals
    {
        public static bool RunProgram = true;
    }

    class Program
    {
        static void Main(string[] args)
        {
            IntegralComputing integralComputing = new IntegralComputing();


            while (Globals.RunProgram)
            {

                int highestPower = GetPolynomialGrade();
                float[] coefficients;
                string function;
                (coefficients, function) = GetCoefficients(highestPower);

                Console.WriteLine(function);
                bool validChoice = false;
                string resultIndefinite = "";
                double resultDefinite = 0;

                while (!validChoice)
                {
                    Console.WriteLine("Input");
                    Console.WriteLine("1 if you want to calculate definite integral");
                    Console.WriteLine("2 if you want to calculate indefine integral");
                    Console.Write("Chosen integral: ");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        validChoice = true;
                        resultDefinite = integralComputing.CalculateDefiniteIntegral(coefficients);
                        Console.WriteLine("\n\n----- RESULT ------");
                        Console.WriteLine(resultDefinite);
                        Console.WriteLine("-------------------\n\n");
                    }
                    else if(choice == "2")
                    {
                        validChoice = true;
                        resultIndefinite = integralComputing.CalculateIndefiniteIntegral(coefficients);
                        Console.WriteLine(resultIndefinite);
                    }
                }

            }

        }


        static int GetPolynomialGrade()
        {

            Console.WriteLine("Input highest power of your polynomial func (max 10)");

            bool isNumber = false;
            int highestPower = 0;

            while (!isNumber)
            {
                Console.Write("Input number 1 - 10 : ");

                string userInput = Console.ReadLine();

                isNumber = Int32.TryParse(userInput, out highestPower);

                if (highestPower > 10 || highestPower < 1)
                {
                    isNumber = false;
                }

            }

            return highestPower;
        }

        static (float [],string) GetCoefficients(int highestPower)
        {
            string wholeFunction = "f(x) = ";
            float [] coefficients = new float[highestPower];
            for (int i = 1; i <= highestPower; i++)
            {
                bool validAnswer = false;
                float coefficientNumber = 0;
                string coefficient = "";
                while (!validAnswer)
                {
                    Console.Write("Input coefficient before x^{0} ", i);
                    coefficient = Console.ReadLine();
                    validAnswer = float.TryParse(coefficient, out coefficientNumber);
                }
                string currentX = coefficient + "x^" + i.ToString();
                if (i != highestPower)
                {
                    currentX = currentX + " + ";
                }
                wholeFunction = String.Concat(wholeFunction, currentX);

                coefficients[i - 1] = coefficientNumber;
                
            }
            return (coefficients, wholeFunction);
        }
    }
}
