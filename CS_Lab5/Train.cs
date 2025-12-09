namespace CS_Lab5
{
    public class Train
    {
        public Locomotive Locomotive { get; set; }
        public List<Wagon> Wagons { get; set; } = new List<Wagon>();
        public int GetTotalPassengers()
        {
            int sum = 0;
            foreach (Wagon wagon in Wagons)
            {
                sum += wagon.PassengerCapacity;
            }
            return sum;
        }
        public int GetTotalLuggage()
        {
            int sum = 0;
            foreach (Wagon wagon in Wagons)
            {
                if(wagon is SleepingWagon w || wagon is PassengerWagon w)
                {

                }
            }
            return sum;
        }
    }
}
