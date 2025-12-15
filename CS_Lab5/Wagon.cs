namespace CS_Lab5
{
    public abstract class Wagon
    {
        public string WagonNumber { get; set; }
        public abstract string GetDescription();
        public abstract WagonType GetWagonType();
    }
}
