// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceSummary.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
//---------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator_TDD
{
    public class InvoiceSummary
    {
        public double totalFare;
        public int length;
        public double averageFairPerRide;

        public InvoiceSummary (double totalFare, int length,double averageFairPerRide)
        {
            this.totalFare = totalFare;
            this.length = length;
            this.averageFairPerRide = averageFairPerRide;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is InvoiceSummary))
            {
                return false;
            }
            InvoiceSummary inputObject = (InvoiceSummary)obj;
            return this.totalFare == inputObject.totalFare && this.length == inputObject.length && this.averageFairPerRide==inputObject.averageFairPerRide;
        }
     
        public override int GetHashCode()
        {
            return this.totalFare.GetHashCode() ^ this.length.GetHashCode()^this.averageFairPerRide.GetHashCode();
        }
    }
}
