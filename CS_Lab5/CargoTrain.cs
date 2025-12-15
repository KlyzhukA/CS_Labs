namespace CS_Lab5
{
    public class CargoTrain : Train
    {
        public string CargoType { get; set; }

        public override string GetTrainType() => "Грузовой";

        public double GetTotalLoadCapacity()
        {
            double total = 0;
            foreach (var wagon in Wagons)
            {
                if (wagon is CargoWagon cargoWagon)
                {
                    total += cargoWagon.MaxLoadCapacity;
                }
            }
            return total;
        }

        public double GetCurrentLoad()
        {
            double total = 0;
            foreach (var wagon in Wagons)
            {
                if (wagon is CargoWagon cargoWagon)
                {
                    total += cargoWagon.CurrentLoad;
                }
            }
            return total;
        }

        public double GetAvailableCapacity()
        {
            return GetTotalLoadCapacity() - GetCurrentLoad();
        }
    }
}
