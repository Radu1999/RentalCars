namespace RentalCars
{
    public class Rental
    {
        public Rental(Customer customer, Car car, int daysRented)
        {
            Customer = customer;
            Car = car;
            DaysRented = daysRented;
        }

        public Customer Customer { get; }
        public Car Car { get; }
        public int DaysRented { get; }

        public double TotalAmount { get; set; }
    }
}