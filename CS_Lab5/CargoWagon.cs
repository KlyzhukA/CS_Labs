using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lab5
{
    public class CargoWagon : Wagon
    {
        public double MaxLoadCapacity { get; set; } 
        public double CurrentLoad { get; set; } = 0; 

        public double AvailableCapacity => MaxLoadCapacity - CurrentLoad;

        public bool LoadCargo(double weight, string cargoType)
        {
            if (AvailableCapacity >= weight)
            {
                CurrentLoad += weight;
                return true;
            }
            return false;
        }

        public void UnloadCargo()
        {
            CurrentLoad = 0;
        }

        public override string GetDescription()
        {
            return $"Грузовой вагон №{WagonNumber}: {MaxLoadCapacity} т, " +
                   $"Загружено: {CurrentLoad} т";
        }

        public override WagonType GetWagonType() => WagonType.Cargo;
    }
}
