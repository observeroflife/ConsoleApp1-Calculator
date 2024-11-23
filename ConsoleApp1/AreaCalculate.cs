using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Runtime.InteropServices.JavaScript.JSType;
public delegate double MyFunctionDelegate(double x);

namespace Calculate
{

    public class AreaCalculate
    {
        public static double TrapRule(MyFunctionDelegate function, double cleanlimleft, double cleanlimright, int cleanstep)
        {
            // a, b - пределы интегрирования
            // n - количество разбиений
            double h = (cleanlimright - cleanlimleft) / cleanstep;
            double sum = 0.5 * (function(cleanlimleft) + function(cleanlimright));
            for (int i = 1; i < cleanstep; i++)
            {
                double x = cleanlimleft + i * h;
                sum += function(x);
            }
            return h * sum;
        }
        public static double LeftRectRule(MyFunctionDelegate function, double cleanlimleft, double cleanlimright, int cleanstep)
        {
            // a, b - пределы интегрирования
            // n - количество разбиений
            double h = (cleanlimright - cleanlimleft) / cleanstep;
            double sum = function(cleanlimleft);
            for (int i = 1; i < cleanstep; i++)
            {
                double x = cleanlimleft + i * h;
                sum += function(x);
            }
            return h * sum;
        }
        public static double AvRectRule(MyFunctionDelegate function, double cleanlimleft, double cleanlimright, int cleanstep)
        {
            // a, b - пределы интегрирования
            // n - количество разбиений
            double h = (cleanlimright - cleanlimleft) / cleanstep;
            double sum = function(cleanlimleft);
            for (int i = 1; i < cleanstep; i++)
            {
                double x = cleanlimleft + i * h/2;
                sum += function(x);
            }
            return h * sum;
        }
    }
}
