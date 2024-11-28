using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab7_Bicycles;


namespace Lab7_Bicycles
{
    public class Bicycle : IComparable<Bicycle>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public double Weight { get; set; }
        public int Gears { get; set; }
        public double Mileage { get; set; }
        public double Distance { get; set; }
        public double Time { get; set; }

        // Конструктор
        public Bicycle(string brand, string model, string type, double weight, int gears, double mileage, double distance, double time)
        {
            Brand = brand;
            Model = model;
            Type = type;
            Weight = weight;
            Gears = gears;
            Mileage = mileage;
            Distance = distance;
            Time = time;
        }

        // Метод для обчислення швидкості
        public double Speed => Distance / Time;

        // Реалізація методу ToString для відображення інформації про велосипед
        public override string ToString()
        {
            return $"Brand: {Brand}, Model: {Model}, Type: {Type}, Weight: {Weight}, Gears: {Gears}, Mileage: {Mileage}, Distance: {Distance}, Time: {Time}, Speed: {Speed:F2}";
        }

        // Реалізація методу CompareTo для порівняння велосипедів (за Mileage, наприклад)
        public int CompareTo(Bicycle other)
        {
            if (other == null)
                return 1;

            // Сортуємо за пробігом (Mileage)
            return this.Mileage.CompareTo(other.Mileage);
        }
    }

}
