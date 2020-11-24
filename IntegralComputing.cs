using System;
namespace integration
{
    public class IntegralComputing
    {



        public double CalculateDefiniteIntegral(float[] coefficients)
        {

            // Approximating definite integral with trapezoidal rule
            // ab f(x)dx = (b-a) * [ f(a) + f(b) ] / 2

            Console.WriteLine("input range from a to b");
            bool validAnswer = false;
            float aNumber = 0;
            float bNumber = 0;

            while (!validAnswer)
            {
                Console.Write("Input a: ");
                string a = Console.ReadLine();
                Console.Write("Input b: ");
                string b = Console.ReadLine();
                bool validA = float.TryParse(a, out aNumber);
                bool validB = float.TryParse(b, out bNumber);

                if (validA && validB && bNumber > aNumber)
                {
                    validAnswer = true;
                }
            }
            float bMinA = bNumber - aNumber;

            double funcA = CalculateFunction(coefficients, aNumber);
            Console.WriteLine("\n\n FUNC A = {0}", funcA);
            double funcB = CalculateFunction(coefficients, bNumber);
            Console.WriteLine("\n\n FUNC B = {0}", funcB);

            double funcAPlusFuncB = funcA + funcB;
            double result = bMinA * (funcAPlusFuncB / 2);

            return result;

        }
        public double CalculateFunction(float[] coefficients, float x)
        {
            double result = 0;

            for (int i = 0; i < coefficients.Length; i++)
            {
                if (coefficients[i] != 0)
                {
                    double temp = 0;
                    temp = Math.Pow(x, i + 1) * coefficients[i];
                    result += temp;
                }
            }

            return result;
        }

        public string CalculateIndefiniteIntegral(float[] coefficients)
        {
            string result = "Integration result = ";
            string[] integralReslut = new string[coefficients.Length];
            for (int i = 0; i < coefficients.Length; i++)
            {
                if (coefficients[i] != 0)
                {
                    string integration = "";
                    int nPlusOne = i + 2;
                    integration += "(" + coefficients[i].ToString() + "/"
                        + nPlusOne.ToString() + ")" + "x^" + nPlusOne.ToString();

                    result += integration;
                    if (i != coefficients.Length - 1)
                    {
                        result += " + ";
                    }
                    else if (i == coefficients.Length - 1)
                    {
                        result += " + C ";
                    }

                }
            }

            return result;
        }







    }
}
