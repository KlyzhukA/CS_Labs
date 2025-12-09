using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lab5
{
    public class SleepingWagon : Wagon
    {
        public int BedsCount { get; set; }
        public int LuggageCapacity { get; set; }

        public override string GetDescription()
        {
            return $"Спальный вагон: {PassengerCapacity} пассажиров, количество багажа(кг) {LuggageCapacity}, {BedsCount} кроватей, комфорт: {ComfortLevel}";
        }
    }
}
 