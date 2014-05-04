namespace Asdo.Mandala2014.Logic.Core
{
    using Asdo.Mandala2014.Logic.Extentions;

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
            ILine line = null;
            double? x = null;


            if (Start.X == End.X)
            {
                line = other;
                x = Start.X;
            }
            else if (other.Start.X == other.End.X)
            {
                line = this;
                x = other.Start.X;
            }
            else
            {
                var equation = new LineEquation(this);
                var otherEquation = new LineEquation(other);

                if (equation.K != otherEquation.K)
                {
                    x = (otherEquation.B - equation.B) / (equation.K - otherEquation.K);
                    line = this;
                }
            }

            return line != null && x.HasValue && x.Value.ContainedBy(line.Start.X, line.End.X)
                       ? new Point(x.Value, new LineEquation(line).Eval(x.Value))
                       : null;
        }
    }
}
