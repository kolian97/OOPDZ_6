namespace OOPDZ_6
{
    internal class Calculator : ICalc
    {
        public event EventHandler<EventArgs> GotResult;
        public double Result = 0;
        private Stack<double> Results = new Stack<double>();
        private Stack<CalcActionLog> actions = new Stack<CalcActionLog>();
        public void Divide(double value)
        {
            if (value == 0)
            {
                actions.Push(new CalcActionLog(CalcAction.Divide, value));
                throw new CalculatorDivideByZeroException("Нельзя делить на ноль!", actions);
            }

            Results.Push(Result);
            Result /= value;
            RaiseEvent();

        }

        public void Multiply(double value)
        {
            double temp = value * Result;
            if (temp > int.MaxValue)
            {
                actions.Push(new CalcActionLog(CalcAction.Multiply, value));
                throw new CalculateOperationCauseOverflowException("Переполнение", actions);
            }
            Results.Push(Result);
            Result *= value;
            RaiseEvent();

        }
        public void Substruct(double value)
        {
            double temp = Result - value;
            if (temp < int.MinValue || (Result == int.MinValue && value == int.MaxValue))
            {
                actions.Push(new CalcActionLog(CalcAction.Substruct, value));
                throw new CalculateOperationCauseOverflowException("Переполнение", actions);
            }
            Results.Push(Result);
            Result -= value;
            RaiseEvent();

        }
        public void Sum(double value)
        {
            ulong temp = (ulong)(value + Result);
            if (temp > int.MaxValue)
            {
                actions.Push(new CalcActionLog(CalcAction.Sum, value));
                throw new CalculateOperationCauseOverflowException("Переполнение", actions);
            }
            Results.Push(Result);
            Result += value;
            RaiseEvent();

        }
        private void RaiseEvent()
        {
            GotResult?.Invoke(this, EventArgs.Empty);
        }
        public void CancelLast()
        {
            if (Results.Count > 0)
            {
                Result = Results.Pop();
                RaiseEvent();
            }

        }
    }
}