using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars
{
    internal class RentalValidator
    {
        static public bool Validate(Rental rental)
        {
            if(rental.Car.PriceCode == PriceCode.Luxury && rental.Customer.FrequentRenterPoints < 3)
            {
                Console.WriteLine("HERE\n");
                return false;
            }

            return true;
        }
    }
}
