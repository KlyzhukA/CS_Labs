namespace CS_Lab5
{
    public class RailwayStation
    {
        public string StationName { get; set; }
        public string City { get; set; }
        public List<Train> Trains { get; set; } = new List<Train>();

        public List<PassengerTrain> GetAvailablePassengerTrains()
        {
            var now = DateTime.Now;
            var availableTrains = new List<PassengerTrain>();

            foreach (var train in Trains)
            {
                if (train is PassengerTrain passengerTrain)
                {
                    if (passengerTrain.DepartureTime > now &&
                        passengerTrain.GetAvailableSeats() > 0)
                    {
                        availableTrains.Add(passengerTrain);
                    }
                }
            }

            return availableTrains;
        }

        public List<CargoTrain> GetAvailableCargoTrains()
        {
            var now = DateTime.Now;
            var availableTrains = new List<CargoTrain>();

            foreach (var train in Trains)
            {
                if (train is CargoTrain cargoTrain)
                {
                    if (cargoTrain.DepartureTime > now &&
                        cargoTrain.GetAvailableCapacity() > 0)
                    {
                        availableTrains.Add(cargoTrain);
                    }
                }
            }

            return availableTrains;
        }
    }
}
