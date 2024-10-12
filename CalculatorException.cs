
namespace OOPDZ_6
{
    internal class CalculatorException : Exception
    {
        public CalculatorException(string v, Stack<CalcActionLog> actionLogs) : base(v)
        {
            ActionLongs = actionLogs;
        }
        public CalculatorException(string v, Exception e) : base(v, e)
        {

        }
        public override string ToString()
        {
            return Message + ": " + string.Join("\n", ActionLongs.Select(x => $"{x.CalcAction} {x.CalcArgument}"));
        }
        public Stack<CalcActionLog> ActionLongs { get; private set; }

    }
    internal class CalculatorDivideByZeroException : CalculatorException
    {

        public CalculatorDivideByZeroException(string v, Stack<CalcActionLog> actionLogs) : base(v, actionLogs)
        {

        }
        public CalculatorDivideByZeroException(string v, Exception e) : base(v, e)
        {

        }

    }
    internal class CalculateOperationCauseOverflowException : CalculatorException

    {
        public CalculateOperationCauseOverflowException(string v, Stack<CalcActionLog> actionLogs) : base(v, actionLogs)
        {

        }
        public CalculateOperationCauseOverflowException(string v, Exception e) : base(v, e)
        {

        }
    }
}