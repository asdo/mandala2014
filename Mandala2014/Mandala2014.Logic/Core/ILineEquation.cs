using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asdo.Mandala2014.Logic.Core
{
    interface ILineEquation
    {
        double K { get; }

        double B { get; }

        double Eval(double x);
    }
}
