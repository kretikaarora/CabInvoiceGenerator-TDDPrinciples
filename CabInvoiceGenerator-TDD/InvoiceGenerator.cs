// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceGenerator.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
//---------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator_TDD
{
    /// <summary>
    /// Invoice Generator
    /// </summary>
    public class InvoiceGenerator
    {
        public RideType rideType;
        public readonly double MINIMUM_COST_PER_KM;
        public readonly int COST_PER_MIN;
        public readonly double MINIMUM_FARE;

        /// <summary>
        /// default constructor
        /// </summary>
        public InvoiceGenerator() { }

        /// <summary>
        /// parameterised constructor
        /// </summary>
        /// <param name="rideType"></param>
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            try
            {
                if (this.rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_MIN = 1;
                    this.MINIMUM_FARE = 5;
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "inavalid ride type");          
            }
        }

        /// <summary>
        /// calculates fare when distance and time is given 
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * this.MINIMUM_COST_PER_KM + time * this.COST_PER_MIN;
            }

            catch (CabInvoiceException)
            {
                ///checking if ride type , distance and time are valid
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "ride should not be null");
                }
                if (time < 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "time is not valid");
                }
                if (distance < 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "distance is not valid");
                }
            }
            return Math.Max(totalFare, this.MINIMUM_FARE);
        }       
    }
}
