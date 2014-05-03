using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asdo.Mandala2014.Logic.Core
{
    public interface ILine
    {
        IPoint Start { get; }

        IPoint End { get; }

        IPoint Cross(ILine other);
    }
}
