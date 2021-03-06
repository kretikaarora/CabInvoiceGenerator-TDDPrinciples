﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceGenerator.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
//---------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
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
        public RideRepository rideRepository;

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
            rideRepository = new RideRepository();
            try
            {
                if (this.rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_MIN = 1;
                    this.MINIMUM_FARE = 5;
                }
                if (this.rideType.Equals(RideType.PREMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_MIN = 2;
                    this.MINIMUM_FARE = 20;
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

        /// <summary>
        /// Calculating Multiple Rides
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        public InvoiceSummary CalculatingMultipleRides(Ride[] rides)
        {
            ///caclulating by taking input of an array of Ride type
            ///calling the Calculate Fare to get fare then adding in total fare 
            double totalFare = 0;
            try
            {
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch (CabInvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "ride should not be null");
                }
            }
            double averageOfRides = totalFare / rides.Length;
            return new InvoiceSummary(totalFare, rides.Length,averageOfRides);
        }

        /// <summary>
        /// Adding rides
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rides"></param>
        public void AddRide(string userId , Ride[] rides)
        {    
            ///calling the add function of ride repository for adding rides into dictionary
            try
            {
                rideRepository.AddRides(userId, rides);
            }
            catch(CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "no rides are taken");
                }
                   
            }
            
        }

        /// <summary>
        /// Getting Invoice Summary
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            ///calling multiple rides func in this class find total fare 
            ///we are passing the getuserride(userid) to get array of rides 
            ///multiple rides is having input as array so this is the reason we were type casting list into array while returning
            try
            {
                return this.CalculatingMultipleRides(rideRepository.GetUserRides(userId));
            }
            catch
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER, "Invalid user id");
            }
        }
    }
}

