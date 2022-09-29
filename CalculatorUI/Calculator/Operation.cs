using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public enum Operation
    {
        Plus,
        Minus,
        Divide,
        Multiply,
        Open,
        Close,
        Power,
    }

    static class OperationFunctions
    {

        public static int GetOperationPriority(Operation op)
        {
            switch (op)
            {

                case Operation.Divide:
                case Operation.Multiply:
                    return 2;
                case Operation.Plus:
                case Operation.Minus:
                    return 1;
                case Operation.Open:
                case Operation.Close:
                    return 0;
                case Operation.Power:
                    return 3;
                default:
                    throw new ArgumentException("Unknow operation");
            };
        }

        public static bool Compare(Operation op1, Operation op2)
        {
            return GetOperationPriority(op1) > GetOperationPriority(op2);
        }

        public static double DoOperation(Operation op, double a, double b)
        {
            switch (op)
            {


                case Operation.Plus:
                    return a + b;
                case Operation.Minus:
                    return a - b;
                case Operation.Divide:
                    return a / b;
                case Operation.Multiply:
                    return a * b;
                case Operation.Power:
                    return Math.Pow(a, b);
                default:
                    throw new ArgumentException("Illegal operation");
            }
        }

    }
}