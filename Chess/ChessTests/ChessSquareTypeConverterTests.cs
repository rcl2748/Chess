using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Tests
{
    [TestClass()]
    public class ChessSquareTypeConverterTests
    {
        [TestMethod()]
        public void ConvertFromTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CanConvertFromTest()
        {
            ChessSquare square = new ChessSquare("1e");
            a.Write(square.File);
        }
    }
}