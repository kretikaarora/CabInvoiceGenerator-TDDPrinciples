// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTest1.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
//---------------------------------------------------------------------------------------------------------------------
using NUnit.Framework;
using CabInvoiceGenerator_TDD;

namespace NUnitTestCabInvoiceGenerator
{
    /// <summary>
    /// Testing Invoice Generator
    /// </summary>
    public class Tests
    {
        public InvoiceGenerator invoiceGenerator;

        /// <summary>
        /// Given Distance And Time Should Return TotalFare
        /// TC 1.1
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            ///Arrange
            double distance = 10;
            int time = 10;
            double expected = 110;
            ///Act
            this.invoiceGenerator = new InvoiceGenerator (RideType.NORMAL);
            double actual = invoiceGenerator.CalculateFare(distance, time);
            ///Assert
            Assert.AreEqual(expected, actual);
        }
    }
}