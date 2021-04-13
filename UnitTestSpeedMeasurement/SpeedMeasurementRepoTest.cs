using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpeedMeasuremetRazor.Exceptions;
using SpeedMeasuremetRazor.Models;
using SpeedMeasuremetRazor.Services;

namespace UnitTestSpeedMeasurement
{
    [TestClass]
    public class SpeedMeasurementRepoTest
    {
        //assert
        [TestMethod()]
        [ExpectedException(typeof(CalibrationException))]
        public void AddSpeedMeasurementTest301()
        {
            //arrange
            SpeedMeasurementRepo sr = new SpeedMeasurementRepo();
            //act
            sr.AddSpeedMeasurement(301, new Location(1, "",Zone.By, 50),"");
        }

        //assert
        [TestMethod()]
        [ExpectedException(typeof(CalibrationException))]
        public void AddSpeedMeasurementTest0()
        {
            //arrange
            SpeedMeasurementRepo sr = new SpeedMeasurementRepo();
            //act
            sr.AddSpeedMeasurement(-1, new Location(1, "", Zone.By, 50), "");
        }

        [TestMethod()]
        public void AddSpeedMeasurementTest1()
        {
            //arrange
            SpeedMeasurementRepo sr = new SpeedMeasurementRepo();
            //act
            int before = sr.AllSpeedMeasurements.Count;
            sr.AddSpeedMeasurement(1, new Location(1, "", Zone.By, 50), "");
            //assert
            Assert.AreEqual(before + 1, sr.AllSpeedMeasurements.Count);
        }
        [TestMethod()]
        public void AddSpeedMeasurementTest300()
        {
            //arrange
            SpeedMeasurementRepo sr = new SpeedMeasurementRepo();
            //act
            int before = sr.AllSpeedMeasurements.Count;
            sr.AddSpeedMeasurement(300, new Location(1, "", Zone.By, 50), "");
            //assert
            Assert.AreEqual(before + 1, sr.AllSpeedMeasurements.Count);
        }
    }
}
