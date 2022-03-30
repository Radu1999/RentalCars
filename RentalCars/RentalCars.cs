using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars
{
    public class RentalCars
    {
        private readonly List<Rental> _rentals = new List<Rental>();
        private double _totalRevenue = 0;
        private readonly int _minimumRenterPointsForDiscount = 5;
        private double _basePricePerDay;
        private double _discountForRenterPoints = 0.05;
        private PriceCode[] _priceCodes;
        private Dictionary<PriceCode, double> _priceCodesDispertion;


        public RentalCars(string name, double basePricePerDay, double discountForRenterPoints, PriceCode[] priceCodes)
        {
            Name = name;
            _basePricePerDay = basePricePerDay;
            _discountForRenterPoints = discountForRenterPoints;
            _priceCodes = priceCodes;
            _priceCodesDispertion = new Dictionary<PriceCode, double>();
        }

        public string Name { get; }

        public void AddRental(Rental rental)
        {
            if(!ValidateRental(rental))
            {
                Console.WriteLine("Invalid rental");
                return;
            }
            _rentals.Add(rental);
            rental.Customer.AddRental(rental);
            rental.TotalAmount = CalculateAmountForRental(rental);
            _totalRevenue += rental.TotalAmount;
            if (_priceCodesDispertion.ContainsKey(rental.Car.PriceCode))
            {
                _priceCodesDispertion[rental.Car.PriceCode] += rental.TotalAmount;
            }
            else
            {
                _priceCodesDispertion[rental.Car.PriceCode] = rental.TotalAmount;
            }
            rental.Customer.FrequentRenterPoints += calculateGainedFrequentRenterPoints(rental);
        }

        public string Statement()
        {
            var r = new StringBuilder("Rental Record for " + Name + "\n");
            r.AppendLine("------------------------------");

            foreach (var each in _rentals)
            {
                r.AppendLine(each.Customer.Name + "\t" + each.Car.Model + "\t" + each.DaysRented + "d \t" + each.TotalAmount + " EUR");

            }
            r.AppendLine("------------------------------");
            r.AppendLine("Total revenue " + _totalRevenue + " EUR");

            return r.ToString();
        }

        public string StatementGroupedByCarCategory()
        {
            var r = new StringBuilder("");
            foreach (var priceCode in _priceCodes)
            {
                if(_priceCodesDispertion.ContainsKey(priceCode))
                {
                    r.AppendLine(priceCode.ToString() + "\t" + _priceCodesDispertion[priceCode]);
                } else
                {
                    r.AppendLine(priceCode.ToString() + "\t" + 0);
                }
            }
            return r.ToString();
        }

 
        private double CalculateAmountForRental(Rental rental)
        {

            double cost = RatePriceManager.calculatePrice(rental, _basePricePerDay);
            cost = RatePriceManager.applyDiscountRenterPoints(rental, cost, _discountForRenterPoints, _minimumRenterPointsForDiscount);
            return cost;

        }

        private int calculateGainedFrequentRenterPoints(Rental rental)
        {
            int frequentRenterPoints = 1;
            if (rental.Car.PriceCode == PriceCode.Premium
                    && rental.DaysRented > 1)
                frequentRenterPoints++;

            return frequentRenterPoints;
        }

        private bool ValidateRental(Rental rental)
        {
            return RentalValidator.Validate(rental) & Array.Exists(_priceCodes, p => p.Equals(rental.Car.PriceCode));
        }
    }
}