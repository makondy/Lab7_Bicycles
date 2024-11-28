using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Bicycles
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bicycles.bin");

            // Читання об'єктів Bicycle з бінарного файлу
            List<Bicycle> bicycles = ReadBicyclesFromBinaryFile(filePath);

            Console.WriteLine("Дані перед сортуванням:");
            foreach (var bicycle in bicycles)
            {
                Console.WriteLine(bicycle);
            }

            // Сортування за пробігом (Mileage) за зростанням
            bicycles.Sort();

            Console.WriteLine("\nДані після сортування:");
            foreach (var bicycle in bicycles)
            {
                Console.WriteLine(bicycle);
            }
        }

        static List<Bicycle> ReadBicyclesFromBinaryFile(string filePath)
        {
            var bicycles = new List<Bicycle>();

            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    while (fs.Position < fs.Length)
                    {
                        try
                        {
                            // Читання даних з файлу в тому ж порядку, як вони були записані
                            string brand = reader.ReadString();
                            string model = reader.ReadString();
                            string type = reader.ReadString();
                            double weight = reader.ReadDouble();
                            int gears = reader.ReadInt32();
                            double mileage = reader.ReadDouble();
                            double distance = reader.ReadDouble();
                            double time = reader.ReadDouble();

                            // Додавання об'єкта Bicycle у список
                            bicycles.Add(new Bicycle(brand, model, type, weight, gears, mileage, distance, time));
                        }
                        catch (EndOfStreamException)
                        {
                            // Якщо кінець потоку, то завершуємо читання
                            Console.WriteLine("Досягнуто кінець файлу.");
                            break;
                        }
                        catch (Exception ex)
                        {
                            // Логування помилок
                            Console.WriteLine($"Помилка при читанні даних: {ex.Message}");
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл не знайдено за шляхом: " + filePath);
            }

            return bicycles;
        }


    }
}

