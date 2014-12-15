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
    public class UnitTile
    {
        [TestMethod]
        public void testTile()
        {
            Tile t = new Tile(new Position(1, 1));
            Assert.IsNotNull(t);
            Assert.IsTrue(t.position.equals(new Position(1, 1)));

        }
    }
}
