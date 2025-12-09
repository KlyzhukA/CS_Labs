using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lab5
{
    public class PassengerWagon : Wagon
    {
        public bool HasAirConditioning { get; set; }
        public int LuggageCapacity { get; set; }

        public override string GetDescription()
        {
            return $"Пассажирский вагон: {PassengerCapacity} пассажиров, {LuggageCapacity} кг багажа, комфорт: {ComfortLevel}";
        }
    }
}
