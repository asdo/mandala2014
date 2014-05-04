using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asdo.Mandala2014.Tests.Logic
{
    using Asdo.Mandala2014.Logic.Core;

    using Moq;

    using Shouldly;

    [TestClass]
    public class LineEquationTest
    {
        [TestMethod]
        public void ShouldCreatedByLine()
        {
            // Given
            var line = new Mock<ILine>();
            line.Setup(l => l.Start).Returns(Mock.Of<IPoint>(p => p.X == 0 && p.Y == 1));
            line.Setup(l => l.End).Returns(Mock.Of<IPoint>(p => p.X == 1 && p.Y == 3));

            // When
            var equation = new LineEquation(line.Object);

            // Then
            equation.K.ShouldBe(2);
            equation.B.ShouldBe(1);
        }

        [TestMethod]
        public void ShouldEval()
        {
            // Given
            var line = new Mock<ILine>();
            line.Setup(l => l.Start).Returns(Mock.Of<IPoint>(p => p.X == 0 && p.Y == 1));
            line.Setup(l => l.End).Returns(Mock.Of<IPoint>(p => p.X == 1 && p.Y == 3));
            var equation = new LineEquation(line.Object);

            // When
            var y = equation.Eval(2);

            // Then
            y.ShouldBe(5);
        }
    }
}
