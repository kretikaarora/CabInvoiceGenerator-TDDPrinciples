// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ride.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
//---------------------------------------------------------------------------------------------------------------------
using System;

namespace CabInvoiceGenerator_TDD
{
    /// <summary>
    /// Ride Class
    /// </summary>
     public class Ride
    {
        /// <summary>
        /// variables for Ride class 
        /// </summary>
        public double distance;
        public int time;
        
        /// <summary>
        /// parameterised Constructor
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        public Ride (double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
