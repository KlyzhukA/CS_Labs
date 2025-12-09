namespace CS_Lab5
{
    public abstract class Wagon
    {
        public int PassengerCapacity { get; set; }
        public string ComfortLevel { get; set; }

        public abstract string GetDescription();
    }
}
