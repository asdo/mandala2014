using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Asdo.Mandala2014.Logic.Core;

namespace Asdo.Mandala2014.Tests
{
    using Shouldly;

    [TestClass]
    public class LineTest
    {
        [TestMethod]
        public void ShouldGetCrossPoint()
        {
            // Given
            var line1 = new Line(Mock.Of<IPoint>(p => p.X == 0 && p.Y == 1), Mock.Of<IPoint>(p => p.X == 2 && p.Y == 5));
            var line2 = new Line(Mock.Of<IPoint>(p => p.X == 3 && p.Y == 1), Mock.Of<IPoint>(p => p.X == 0 && p.Y == 4));

            // When
            var point = line1.Cross(line2);

            // Then
            point.X.ShouldBe(1);
            point.Y.ShouldBe(3);
        }        
        
        [TestMethod]
        public void ShouldGetCrossPointIndependetOrder()
        {
            // Given
            var line1 = new Line(Mock.Of<IPoint>(p => p.X == 0 && p.Y == 1), Mock.Of<IPoint>(p => p.X == 2 && p.Y == 5));
            var line2 = new Line(Mock.Of<IPoint>(p => p.X == 3 && p.Y == 1), Mock.Of<IPoint>(p => p.X == 0 && p.Y == 4));

            // When
            var point1 = line1.Cross(line2);
            var point2 = line2.Cross(line1);

            // Then
            point1.X.ShouldBe(1);
            point1.Y.ShouldBe(3);

            point2.X.ShouldBe(1);
            point2.Y.ShouldBe(3);
        }        

        [TestMethod]
        public void ShouldGetCrossPointWithVerticalLine()
        {
            // Given
            var line1 = new Line(Mock.Of<IPoint>(p => p.X == 0 && p.Y == 1), Mock.Of<IPoint>(p => p.X == 2 && p.Y == 5));
            var line2 = new Line(Mock.Of<IPoint>(p => p.X == 1 && p.Y == 1), Mock.Of<IPoint>(p => p.X == 1 && p.Y == 4));

            // When
            var point = line1.Cross(line2);

            // Then
            point.X.ShouldBe(1);
            point.Y.ShouldBe(3);
        }

        [TestMethod]
        public void ShouldGetCrossPointWithHorizontalLine()
        {
            // Given
            var line1 = new Line(Mock.Of<IPoint>(p => p.X == 3 && p.Y == 1), Mock.Of<IPoint>(p => p.X == 0 && p.Y == 4));
            var line2 = new Line(Mock.Of<IPoint>(p => p.X == 0 && p.Y == 2), Mock.Of<IPoint>(p => p.X == 4 && p.Y == 2));

            // When
            var point = line1.Cross(line2);

            // Then
            point.X.ShouldBe(2);
            point.Y.ShouldBe(2);
        }

        [TestMethod]
        public void ShouldNotGetCrossPoint()
        {
            // Given
            var line1 = new Line(Mock.Of<IPoint>(p => p.X == 3 && p.Y == 1), Mock.Of<IPoint>(p => p.X == 0 && p.Y == 4));
            var line2 = new Line(Mock.Of<IPoint>(p => p.X == 5 && p.Y == 2), Mock.Of<IPoint>(p => p.X == 3 && p.Y == 3));

            // When
            var point = line1.Cross(line2);

            // Then
            point.ShouldBe(null);
        }
    }
}
