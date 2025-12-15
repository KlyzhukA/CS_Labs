namespace CS_Lab5
{
    public class Locomotive
    {
        public string SerialNumber { get; set; }
        public int Power { get; set; }
        public double MaxSpeed { get; set; }
        public int MaxWagons { get; set; }

        public string GetDescription()
        {
            return $"Локомотив {SerialNumber}, мощность: {Power} л.с., " +
                   $"Макс. скорость: {MaxSpeed} км/ч, Макс. вагонов: {MaxWagons}";
        }
    }
}
