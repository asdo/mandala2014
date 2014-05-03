using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Asdo.Mandala2014.Logic.Extentions;

namespace Asdo.Mandala2014.Logic.Core
{
    public sealed class Line : ILine
    {
        private readonly IPoint start;
        private readonly IPoint end;

        public Line(IPoint start, IPoint end)
        {
            this.start = start;
            this.end = end;
        }

        public IPoint Start
        {
            get { return start; }
        }

        public IPoint End
        {
            get { return end; }
        }

        public IPoint Cross(ILine other)
        {
            if (Start.X != End.X && other.Start.X != other.End.X)
            {
                var eq0 = new LineEquation(this);
                var eq1 = new LineEquation(other);

                if (eq0.K != eq1.K)
                {
                    var x = (eq1.B - eq0.B) / (eq0.K - eq1.K);

                    if (x.ContainedBy(Start.X, End.X))
                    {
                        return new Point(x, eq0.Eval(x));
                    }
                }
            }
            else
            {
                ILine line = null;
                double? x = null;

                if (Start.X != End.X)
                {
                    line = other;
                    x = Start.X;
                }
                else if (other.Start.X != other.End.X)
                {
                    line = this;
                    x = other.Start.X;
                }

                if (line != null && x.HasValue && x.Value.ContainedBy(line.Start.X, line.End.X))
                {
                    return new Point(x.Value, new LineEquation(line).Eval(x.Value));
                }
            }
            return null;
        }
    }
}
