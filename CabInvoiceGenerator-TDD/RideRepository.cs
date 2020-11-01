// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RideRepository.cs" company="Capgemini">
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
    /// Class Ride Repository for multiple users that ride
    /// </summary>
    public class RideRepository
    {
        /// <summary>
        /// to store multiple users using using  id and their rides in list
        /// </summary>
        Dictionary<string, List<Ride>> userRidesDictionary = new Dictionary<string, List<Ride>>();

        /// <summary>
        /// Getting user Rides in array form
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Ride[] GetUserRides(string userId)
        {
            ///checking is userid exists 
            ///otherwise returning list and type casting it to array 
            if(!userRidesDictionary.ContainsKey(userId))
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER, " User Id Does not exsist");
            }
            if(userRidesDictionary.Values.Count==0)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "No rides taken");
            }
            return userRidesDictionary[userId].ToArray();
        }

        /// <summary>
        /// Adiing rides to dictionary
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rides"></param>
        public void AddRides(string userId , Ride[] rides)
        {
            ///adding into list and checking if user exists alreat then adding into that user id
            ///otherwise creating a new key of userid in dic and adding list
            List<Ride> list = new List<Ride>();
            list.AddRange(rides);
            if (userRidesDictionary.ContainsKey(userId))

            {
                userRidesDictionary[userId].AddRange(list);
            }
            else
                userRidesDictionary.Add(userId,list);
        }
    }
}
