using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Asdo.Mandala2014.Logic.Core;

namespace Asdo.Mandala2014.Tests
{
    [TestClass]
    public class LineTest
    {
        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod]
        public void ShouldEvalLineEquation()
        {
            // Given
            var p0 = Mock.Of<IPoint>(p => p.X == 0 && p.Y == 1);
            var p1 = Mock.Of<IPoint>(p => p.X == 0 && p.Y == 3);

            // When
            var line = new Line(p0, p1);

            // Then
            Assert.AreEqual(2, line.K, "K");
            Assert.AreEqual(1, line.B, "B");
        }
    }
}
