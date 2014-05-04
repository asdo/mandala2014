using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asdo.Mandala2014.Logic.Extentions
{
    public static class MathExtentions
    {
        public const double Epsilon = 1e-6;

        public static bool ContainedBy(this double x, double a, double b)
        {
            var x0 = Math.Min(a, b);
            var x1 = Math.Max(a, b);

            return x >= x0 && x <= x1;
        }

        public static bool Equals(this double x, double y)
        {
            return Math.Abs(x - y) < Epsilon;
        }
    }
}
