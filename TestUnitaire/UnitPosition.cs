using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetPOO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestUnitaire
{
    [TestClass]
    public class UnitPosition
    {
        [TestMethod]
        public void testPosition()
        {
            Position p = new Position(1, 2);
            Assert.IsNotNull(p);
            Assert.AreEqual(1, p.x);
            Assert.AreEqual(2, p.y);
        }

        [TestMethod]
        public void testsetPosition()
        {
            Position p = new Position(1, 2);
            p.setPosition(new Position(5,6));
            Assert.IsNotNull(p);
            Assert.AreEqual(5, p.x);
            Assert.AreEqual(6, p.y);
        }

        [TestMethod]
        public void testequals()
        {
            Position p = new Position(1, 2);
            Position p0 = new Position(1, 2);
            Position p1 = new Position(1, 3);
            Assert.IsTrue(p.equals(p0));
            Assert.IsFalse(p.equals(p1));
        }
    }
}
