namespace OOPDZ_6
{
    internal class CalcActionLog
    {
        public CalcAction CalcAction { get; private set; }
        public double CalcArgument { get; private set; }
        public CalcActionLog(CalcAction calcAction, double cslcArgument)
        {
            CalcAction = calcAction;
            CalcArgument = cslcArgument;
        }
    }
}