namespace CS_Lab5
{
    public class PassengerWagon : Wagon
    {
        public int PassengerCapacity { get; set; }
        public int SeatsOccupied { get; set; } = 0;
        public ComfortType ComfortLevel { get; set; }
        public double TicketPrice { get; set; }
        public int AvailableSeats => PassengerCapacity - SeatsOccupied;

        public bool BookSeat(int count = 1)
        {
            if (AvailableSeats >= count)
            {
                SeatsOccupied += count;
                return true;
            }
            return false;
        }

        public bool CancelBooking(int count = 1)
        {
            if (SeatsOccupied >= count)
            {
                SeatsOccupied -= count;
                return true;
            }
            return false;
        }

        public override string GetDescription()
        {
            return $"Вагон №{WagonNumber}: {PassengerCapacity} мест, " +
                   $"Свободно: {AvailableSeats}, Цена: {TicketPrice:C}";
        }

        public override WagonType GetWagonType() => WagonType.Passenger;
    }
}
