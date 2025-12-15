namespace CS_Lab5
{
    public abstract class Train
    {
        public string TrainNumber { get; set; }
        public Locomotive Locomotive { get; set; }
        public List<Wagon> Wagons { get; set; } = new List<Wagon>();
        public string Route { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public abstract string GetTrainType();

        public void PrintTrainInfo()
        {
            Console.WriteLine($"=== Поезд №{TrainNumber} ===");
            Console.WriteLine($"Тип: {GetTrainType()}");
            Console.WriteLine($"Маршрут: {Route}");
            Console.WriteLine($"Отправление: {DepartureTime}, Прибытие: {ArrivalTime}");
            Console.WriteLine($"Локомотив: {Locomotive?.GetDescription()}");
            Console.WriteLine($"Количество вагонов: {Wagons.Count}");

            Console.WriteLine("\nСостав поезда:");
            foreach (var wagon in Wagons)
            {
                Console.WriteLine($"{wagon.WagonNumber}  - {wagon.GetDescription()}");
            }
        }
    }
}
