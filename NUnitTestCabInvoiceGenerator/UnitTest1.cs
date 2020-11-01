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
            this.invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double actual = invoiceGenerator.CalculateFare(distance, time);
            ///Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Given Multiple Rides Should Return Invoice Summary
        /// TC 2.1 , 3.1
        /// </summary>
        [Test]
        public void GivenMultipleRide_ShouldReturnInvoiceSummary()
        {
            ///Arrange            
            this.invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 9), new Ride(0.1, 1), new Ride(0.2, 1) };
            ///Act
            InvoiceSummary expectedSummary = invoiceGenerator.CalculatingMultipleRides(rides);
            var expectedSummaryGetHash = expectedSummary.GetHashCode();
            InvoiceSummary actualSummary = new InvoiceSummary(39.0, 3, 13);
            var actualSummaryGetHash = actualSummary.GetHashCode();
            ///Assert
            Assert.AreEqual(expectedSummary, actualSummary);
            Assert.AreEqual(actualSummaryGetHash, expectedSummaryGetHash);

            //Assert.AreEqual(expectedSummary, actualSummary);
            ///Assert can be done using AreEqual method or By using getting the hashcode and then comparing the hashcode
            ///method overide for Equal and GetHashCode is in InvoiceSummaryClass

        }

        /// <summary>
        /// Given Rides For Different Users Should Return InvoiceSummary
        /// TC 4.1
        /// </summary>
        [Test]
        public void GivenRidesForDifferentUsersShouldReturnInvoiceSummary()
        {
            ///passing type normal through invoice generator
            ///passing userid and rides array for first user to addride function in invoice generator
            ///invoice generator will further pass it to ride repository to add in dictionary
            ///repeated same for usertwo
            ///getting the user invoice and asserting expected and actual
            this.invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] ridesForFirstCustomer = { new Ride(2.0, 5), new Ride(0.1, 1)};
            string userIdForFirstCustomer = "100";
            invoiceGenerator.AddRide(userIdForFirstCustomer, ridesForFirstCustomer);
            Ride[] ridesForSecondCustomer = { new Ride(2.0, 10), new Ride(0.1, 2) };
            string userIdForSecondCustomer = "200";
            invoiceGenerator.AddRide(userIdForSecondCustomer, ridesForSecondCustomer);
            InvoiceSummary actualSummary = invoiceGenerator.GetInvoiceSummary(userIdForFirstCustomer);
            InvoiceSummary expectedSummary = new InvoiceSummary(30,2,15);
            Assert.AreEqual(actualSummary, expectedSummary);
        }
    }
}