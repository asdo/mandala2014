namespace Asdo.Mandala2014.Logic.Core
{
    using System;

    public class LineEquation : ILineEquation
    {
        private readonly double k;
        private readonly double b;

        public LineEquation(ILine line)
        {
            k = (line.Start.Y - line.End.Y) / (line.Start.X - line.End.X);
            b = line.Start.Y - k * line.Start.X;
        }

        public double K
        {
            get { return k; }
        }

        public double B
        {
            get { return b; }
        }

        public double Eval(double x)
        {
            return K * x + B;
        }
    }
}
