using System;
using System.Diagnostics;
using System.IO;

namespace CalculatorLibrary
{
    public class Calculator
    {

        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calcator.log");
            Trace.Listeners.Add(new TextWriterTraceListener(logFile));
            Trace.AutoFlush = true;
            Trace.WriteLine("Starting Calculator Log");
            Trace.WriteLine(String.Format("Started {0}", System.DateTime.Now.ToString()));
        }
        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN;

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    WriteLog(num1, num2, result, "+");
                    break;
                case "s":
                    result = num1 - num2;
                    WriteLog(num1, num2, result, "-");
                    break;
                case "m":
                    result = num1 * num2;
                    WriteLog(num1, num2, result, "*");
                    break;
                case "d":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        WriteLog(num1, num2, result, "/");
                    }
                    break;
                default:
                    break;
            }
            return result;
        }

        private void WriteLog(double num1, double num2, double result, string op)
        {
            Trace.WriteLine(String.Format("{0} " + op + " {1} = {2}", num1, num2, result, op));
        }
    }
}