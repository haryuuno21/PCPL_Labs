namespace Lab5_Delegates
{
    delegate double MathFunction(double p1, int p2);
    internal class Delegates
    {
        static double Pow(double x, int n) { return Math.Pow(x, n); }
        static double Root(double x, int n) { return Math.Pow(x, 1.0d / n); }

        static void MathFunctionMethodGeneric(double x, int n, Func<double, int, double> MathFunctionParam)
        {
            double Result = MathFunctionParam(x, n);
            Console.WriteLine(Result);
        }
        static void MathFunctionMethod(double x, int n, MathFunction MathFunctionParam)
        {
            double Result = MathFunctionParam(x, n);
            Console.WriteLine(Result);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Возведение 4.5 в степень 3:");
            MathFunctionMethod(4.5, 3, Pow);
            Console.WriteLine("Корень 3 степени из числа 15.625:");
            MathFunctionMethod(15.625, 3, Root);
            Console.WriteLine("Возведение 2.5 в степень 3, аргумент – лямбда-выражение:");
            MathFunctionMethod(2.5, 3, (x, n) => Math.Pow(x, n));

            Console.WriteLine("\n\t\tИспользование обобщенного делегата Func<double, int, double>\n");

            Console.WriteLine("Возведение 4.5 в степень 3:");
            MathFunctionMethodGeneric(4.5, 3, Pow);
            Console.WriteLine("Корень 3 степени из числа 15.625:");
            MathFunctionMethodGeneric(15.625, 3, Root);
            Console.WriteLine("Возведение 2.5 в степень 3, аргумент – лямбда-выражение:");
            MathFunctionMethodGeneric(2.5, 3, (x, n) => Math.Pow(x, n));
        }
    }
}