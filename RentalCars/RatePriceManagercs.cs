using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars
{
    public class RatePriceManager
    {
        static private (double, int, double) getPriceCoeficients(PriceCode priceCode, int daysRented)
        {
            double deviationFromBasePrice = 0;
            int noPenaltyDays = 0;
            double penaltyDeviationFromBasePrice = 0;

            switch (priceCode)
            {
                case PriceCode.Regular:
                    noPenaltyDays = 2;
                    deviationFromBasePrice = 1;
                    penaltyDeviationFromBasePrice = 0.75;
                    break;
                case PriceCode.Premium:
                    noPenaltyDays = daysRented;
                    deviationFromBasePrice = 1.5;
                    penaltyDeviationFromBasePrice = 0;
                    break;
                case PriceCode.Mini:
                    noPenaltyDays = 3;
                    deviationFromBasePrice = 0.75;
                    penaltyDeviationFromBasePrice = 0.5;
                    break;
                case PriceCode.Luxury:
                    noPenaltyDays = daysRented;
                    deviationFromBasePrice = 2.33;
                    penaltyDeviationFromBasePrice = 0;
                    break;
            }


            return (deviationFromBasePrice, noPenaltyDays, penaltyDeviationFromBasePrice);
        }

        static public double calculatePrice(Rental rental, double basePrice)
        {
            (double deviationFromBasePrice,
             int noPenaltyDays,
             double penaltyDeviationFromBasePrice) = getPriceCoeficients(rental.Car.PriceCode, rental.DaysRented);

            double price = deviationFromBasePrice * basePrice * rental.DaysRented;
            if(rental.DaysRented > noPenaltyDays)
            {
                price += (rental.DaysRented - noPenaltyDays) * basePrice * penaltyDeviationFromBasePrice;
            }

            return price;
        }

        static public double applyDiscountRenterPoints(Rental rental, double price, double discount, int minimumRenterPoints)
        {
            if(rental.Car.PriceCode == PriceCode.Luxury)
            {
                return price;
            }
            if (rental.Customer.FrequentRenterPoints >= minimumRenterPoints)
            {
                return price * (1 - discount);
            }
            return price;
        }
    }
}
