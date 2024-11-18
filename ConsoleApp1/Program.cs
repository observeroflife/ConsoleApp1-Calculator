using static System.Runtime.InteropServices.JavaScript.JSType;
public delegate double MyFunctionDelegate(double x);
public class Area
{
    public static double TrapRule(MyFunctionDelegate function, double cleanlimleft, double cleanlimright, int cleanstep)
    {
        // a, b - пределы интегрирования
        // n - количество разбиений
        double h = (cleanlimright - cleanlimleft) / cleanstep;
        double sum = 0.5 * (function(cleanlimleft) + function(cleanlimright));
        for (int i = 1; i < cleanstep                                      ; i++)
        {
            double x = cleanlimleft + i * h;
            sum += function(x);
        }
        return h * sum;
    }
}

public class Program
{
    
    static double myFunction(double x)
    {
        return Math.Cos(x);
    }
    public static void Main(string[] args)
    {
        bool endApp = false;
        // Display title as the C# console calculator app.
        Console.WriteLine("Find Scos in C#\r");
        Console.WriteLine("------------------------\n");

        while (!endApp)
        {
            // Declare variables and set to empty.
            string limleft = "";
            string limright = "";
            string step = "";
            double result = 0;

            // Ask the user to type the first number.
            Console.Write("Type a left limit to calculate, and then press Enter: ");
            limleft = Console.ReadLine();

            double cleanlimleft = 0;
            while (!double.TryParse(limleft, out cleanlimleft))
            {
                Console.Write("This is not valid input. Please enter correct value: ");
                limleft = Console.ReadLine();
            }

            // Ask the user to type the second number.
            Console.Write("Type a right limit to calculate, and then press Enter: ");
            limright = Console.ReadLine();

            double cleanlimright = 0;
            while (!double.TryParse(limright, out cleanlimright))
            {
                Console.Write("This is not valid input. Please enter correct value: ");
                limright = Console.ReadLine();
            }
            // Ask the user to type the second number.
            Console.Write("Type a step to calculate, and then press Enter: ");
            step = Console.ReadLine();

            int cleanstep = 0;
            while (!int.TryParse(step, out cleanstep))
            {
                Console.Write("This is not valid input. Please enter correct value: ");
                step = Console.ReadLine();
            }


            try
            {
                result = Area.TrapRule(myFunction, cleanlimleft, cleanlimright, cleanstep);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("This operation will result in a mathematical error.\n");
                }
                else Console.WriteLine("Your result: {0:0.##}\n", result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
            }

            Console.WriteLine("------------------------\n");

            // Wait for the user to respond before closing.
            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n"); // Friendly linespacing.
        }
        return;
    }
}


// Пример функции
// Вычисление интеграла от 0 до Pi/2
//double result = NumericalIntegration.TrapezoidalRule(myFunction, 0, Math.PI / 2, 1000);
//Console.WriteLine(result);