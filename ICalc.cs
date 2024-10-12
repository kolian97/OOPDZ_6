namespace OOPDZ_6
{
    internal interface ICalc
    {
        event EventHandler<EventArgs> GotResult;

        void Sum(double Value);
        void Substruct(double Value);
        void Multiply(double Value);
        void Divide(double Value);
        void CancelLast();
    }
}
