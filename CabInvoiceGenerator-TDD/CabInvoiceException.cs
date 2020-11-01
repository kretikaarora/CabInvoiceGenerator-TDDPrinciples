// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CabInvoiceException.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
//---------------------------------------------------------------------------------------------------------------------
using System;

namespace CabInvoiceGenerator_TDD
{
    /// <summary>
    /// Cab Invoice Exception Class
    /// </summary>
    [Serializable]
    public class CabInvoiceException : Exception
    {
        public ExceptionType exceptionType;

        /// <summary>
        /// enum for types exception thown
        /// </summary>
        public enum ExceptionType
        {
          INVALID_RIDE_TYPE, INVALID_DISTANCE, INVALID_TIME, NULL_RIDES,INVALID_USER
        }

        /// <summary>
        /// Parameterised constructor 
        /// </summary>
        /// <param name="innerException"></param>
        /// <param name="message"></param>
        public CabInvoiceException(ExceptionType innerException, string message) : base(message)
        {
            this.exceptionType = innerException;
        }
    }
}
