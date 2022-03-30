using System;

namespace RentalCars
{
    class Program
    {
        static void Main(string[] args)
        {
            PriceCode[] priceCodesIasi = {PriceCode.Regular, PriceCode.Premium, PriceCode.Mini};
            RentalCars store = new RentalCars("Iasi Rentals", 20, 0.05, priceCodesIasi);

            var customer1 = new Customer("Ion Popescu");
            var customer2 = new Customer("Mihai Chirica");
            var customer3 = new Customer("Gigi Becali");

            store.AddRental(new Rental(customer1, new Car(PriceCode.Regular, "Ford Focus"), 1));
            store.AddRental(new Rental(customer3, new Car(PriceCode.Regular, "Renault Clio"), 3));
            store.AddRental(new Rental(customer1, new Car(PriceCode.Premium, "BMW 330i"), 1));
            store.AddRental(new Rental(customer3, new Car(PriceCode.Premium, "Volvo XC90"), 5));
            store.AddRental(new Rental(customer2, new Car(PriceCode.Mini, "Toyota Aygo"), 2));
            store.AddRental(new Rental(customer1, new Car(PriceCode.Mini, "Hyundai i10"), 4));
            store.AddRental(new Rental(customer3, new Car(PriceCode.Premium, "Volvo XC90"), 2));
            store.AddRental(new Rental(customer3, new Car(PriceCode.Premium, "Mercedes E320"), 1));

            Console.WriteLine(store.Statement());


            var customer4 = new Customer("Jada Smith");
            var customer5 = new Customer("Chris Rock");
            var customer6 = new Customer("Will Smith");

            PriceCode[] priceCodesBucharest = { PriceCode.Regular, PriceCode.Premium, PriceCode.Mini, PriceCode.Premium, PriceCode.Luxury};
            RentalCars storeB = new RentalCars("Bucharest Rentals", 30, 0.05, priceCodesBucharest);
            storeB.AddRental(new Rental(customer4, new Car(PriceCode.Regular, "Ford Focus"), 1));
            storeB.AddRental(new Rental(customer6, new Car(PriceCode.Regular, "Renault Clio"), 3));
            storeB.AddRental(new Rental(customer4, new Car(PriceCode.Premium, "BMW 330i"), 1));
            storeB.AddRental(new Rental(customer6, new Car(PriceCode.Premium, "Volvo XC90"), 3));
            storeB.AddRental(new Rental(customer5, new Car(PriceCode.Mini, "Toyota Aygo"), 2));
            storeB.AddRental(new Rental(customer4, new Car(PriceCode.Mini, "Hyundai i10"), 4));
            storeB.AddRental(new Rental(customer6, new Car(PriceCode.Premium, "Volvo XC90"), 2));
            storeB.AddRental(new Rental(customer6, new Car(PriceCode.Premium, "Mercedes E320"), 1));
            storeB.AddRental(new Rental(customer6, new Car(PriceCode.Luxury, "Lamborghini"), 1));

            Console.WriteLine(storeB.Statement());
            Console.WriteLine(storeB.StatementGroupedByCarCategory());

        }
    }
}
