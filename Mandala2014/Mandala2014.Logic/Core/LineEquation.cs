using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asdo.Mandala2014.Logic.Core
{
    public class LineEquation : ILineEquation
    {
        private double k;
        private double b;

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
            throw new NotImplementedException();
        }
    }
}
