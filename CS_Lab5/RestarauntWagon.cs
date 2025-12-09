namespace CS_Lab5
{
    public class RestarauntWagon : Wagon
    {
        public int TablesCount { get; set; }

        public override string GetDescription()
        {
            return $"Ресторанный вагон: {TablesCount} столов, комфорт: {ComfortLevel}";
        }
    }
}
