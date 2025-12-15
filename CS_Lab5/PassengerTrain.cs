namespace CS_Lab5
{
    public class PassengerTrain : Train
    {
        public override string GetTrainType() => "Пассажирский";

        public int GetTotalPassengers()
        {
            int total = 0;
            foreach (var wagon in Wagons)
            {
                if (wagon is PassengerWagon passengerWagon)
                {
                    total += passengerWagon.PassengerCapacity;
                }
            }
            return total;
        }

        public int GetAvailableSeats()
        {
            int total = 0;
            foreach (var wagon in Wagons)
            {
                if (wagon is PassengerWagon passengerWagon)
                {
                    total += passengerWagon.AvailableSeats;
                }
            }
            return total;
        }

        public void SortWagonsByComfort()
        {
            var passengerWagons = Wagons.OfType<PassengerWagon>().ToList();
            passengerWagons = passengerWagons.OrderBy(w => w.ComfortLevel).ToList();
            Wagons = passengerWagons.Cast<Wagon>().ToList();
        }
    }
}
