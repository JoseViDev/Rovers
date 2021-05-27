using Microsoft.VisualStudio.TestTools.UnitTesting;
using NasaMars;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void TestGrid()
        {
            // confirm that valid grid data works

            Assert.AreEqual(0, NasaMars.Grid.Instance.LimitX);
            Assert.AreEqual(0, NasaMars.Grid.Instance.LimitY);

            string input = "3 5";
            NasaMars.InputParser.ParseGrid(input);

            Assert.AreEqual(3, NasaMars.Grid.Instance.LimitX);
            Assert.AreEqual(5, NasaMars.Grid.Instance.LimitY);
        }

        [TestMethod]
        public void TestOneTour()
        {
            // confirm that a rover is parsed correctly

            string input = @"3 5
1 2 N
LRM";
            List<Tour> output = NasaMars.InputParser.ParseTours(input);

            Assert.AreEqual(1, output.Count);
            Assert.AreEqual(1, output[0].Vehicle.X);
            Assert.AreEqual(2, output[0].Vehicle.Y);
            Assert.AreEqual(Directions.North, output[0].Vehicle.Direction);
            Assert.AreEqual(Instruction.Left, output[0].Instructions[0]);
            Assert.AreEqual(Instruction.Right, output[0].Instructions[1]);
            Assert.AreEqual(Instruction.Move, output[0].Instructions[2]);
        }

        [TestMethod]
        public void TestSeveralTours()
        {
            // confirm that the parser can handle multiple rovers

            string input = @"9 9
3 4 N
LRM
3 4 N
LRM
3 4 N
LRM";
            List<Tour> output = NasaMars.InputParser.ParseTours(input);

            Assert.AreEqual(3, output.Count);
            foreach (Tour tour in output)
            {
                Assert.AreEqual(3, tour.Vehicle.X);
                Assert.AreEqual(4, tour.Vehicle.Y);
                Assert.AreEqual(Directions.North, tour.Vehicle.Direction);
                Assert.AreEqual(Instruction.Left, tour.Instructions[0]);
                Assert.AreEqual(Instruction.Right, tour.Instructions[1]);
                Assert.AreEqual(Instruction.Move, tour.Instructions[2]);
            }
        }

    }
}
