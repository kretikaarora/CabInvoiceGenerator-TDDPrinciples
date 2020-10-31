using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator_TDD
{
    public class InvoiceSummary
    {
        public double totalFare;
        public int length;

        public InvoiceSummary (double totalFare, int length)
        {
            this.totalFare = totalFare;
            this.length = length;         
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
            return this.totalFare == inputObject.totalFare && this.length == inputObject.length;
        }
     
        public override int GetHashCode()
        {
            return this.totalFare.GetHashCode() ^ this.length.GetHashCode();
        }
    }
}
