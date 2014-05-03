using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asdo.Mandala2014.Logic.Core
{
    public sealed class Point : IPoint
    {
        private readonly double x;

        private readonly double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get { return x; }
        }

        public double Y
        {
            get { return y; }
        }
    }
}
