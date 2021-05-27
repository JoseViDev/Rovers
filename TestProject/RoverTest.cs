using Microsoft.VisualStudio.TestTools.UnitTesting;
using NasaMars;
using System;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass]
    public class RoverTest
    {
        [TestMethod]
        public void TestMove()
        {
            // confirm that a rover moves correctly

            Tour tour = new Tour();
            tour.Vehicle = new Rover();
            tour.Vehicle.X = 0;
            tour.Vehicle.Y = 0;
            tour.Vehicle.Direction = Directions.North;
            tour.Instructions.Add(Instruction.Move);
            tour.Instructions.Add(Instruction.Right);
            tour.Instructions.Add(Instruction.Move);
            tour.Instructions.Add(Instruction.Move);
            List<Tour> tours = new List<Tour>();
            tours.Add(tour);

            Grid.Instance.LimitX = 10;
            Grid.Instance.LimitY = 10;

            NasaMars.VehicleManager.Execute(tours);

            Assert.AreEqual(2, tour.Vehicle.X);
            Assert.AreEqual(1, tour.Vehicle.Y);
            Assert.AreEqual(Directions.East, tour.Vehicle.Direction);
            Assert.AreEqual(State.Successful, tour.Vehicle.Status);
        }

        [TestMethod]
        public void TestOutOfBoundaries()
        {
            // confirm that the rover cannot go out of bounds

            Tour tour = new Tour();
            tour.Vehicle = new Rover();
            tour.Vehicle.X = 0;
            tour.Vehicle.Y = 0;
            tour.Vehicle.Direction = Directions.North;
            tour.Instructions.Add(Instruction.Move);
            tour.Instructions.Add(Instruction.Right);
            tour.Instructions.Add(Instruction.Move);
            tour.Instructions.Add(Instruction.Move);
            tour.Instructions.Add(Instruction.Move);
            tour.Instructions.Add(Instruction.Move);
            List<Tour> tours = new List<Tour>();
            tours.Add(tour);

            Grid.Instance.LimitX = 3;
            Grid.Instance.LimitY = 3;

            NasaMars.VehicleManager.Execute(tours);

            Assert.AreEqual(3, tour.Vehicle.X);
            Assert.AreEqual(1, tour.Vehicle.Y);
            Assert.AreEqual(Directions.East, tour.Vehicle.Direction);
            Assert.AreEqual(State.Unsuccessful, tour.Vehicle.Status);
        }

    }
}
