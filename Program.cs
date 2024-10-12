//Доработайте класс калькулятора способным работать как с целочисленными
//так и с дробными числами. (возможно стоит задействовать перегрузку операций).
namespace OOPDZ_6
{
    internal class Program
    {
        static void Calculator_GotResult(object sendler, EventArgs eventArgs)
        {
            Console.WriteLine($"{((Calculator)sendler).Result}");
        }
        //static void Calculator_GotResultTwo(object sendler, EventArgs eventArgs)
        //{
        //    Console.WriteLine($"result = {((Calculator)sendler).Result}");
        //}
        static void Execute(Action<double> action, double value = 10)
        {
            try
            {
                action.Invoke(value);
            }
            catch (CalculatorDivideByZeroException ex)
            {
                Console.WriteLine(ex);
            }

            catch (CalculateOperationCauseOverflowException ex)
            {
                Console.WriteLine(ex);
            }

        }
        static void Main(string[] args)
        {
            ICalc calc = new Calculator();

            calc.GotResult += Calculator_GotResult;
            //calc.GotResult += Calculator_GotResultTwo;
            Execute(calc.Substruct, 5.5);
            Execute(calc.Substruct, 4.96);
            Execute(calc.Sum, 100.89);
            Execute(calc.Sum, 10.5);
            Execute(calc.Divide, 13.8);
            Execute(calc.Multiply, 6.7);

            //Execute(calc.Substruct);



            //calc.CancelLast();


        }
    }
}