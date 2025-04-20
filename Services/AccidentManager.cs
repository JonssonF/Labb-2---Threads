using System.Xml.Linq;

namespace Labb_2___Threads.Models
{
    public static class AccidentManager
    {
        private static readonly Random rng = new Random();
        private static readonly object _lock = new object();

        public static void Accident(Car car)
        {
            int accidentChance;

            lock (_lock)
            {
               accidentChance = rng.Next(1, 51);
            }

                if (accidentChance == 1)
                {
                    Console.WriteLine($"Looks like {car.Driver} forgot to fuel up {car.Name}!");
                    Thread.Sleep(15000);
                }
                else if (accidentChance <= 3)
                {
                    Console.WriteLine($"OH MY GOD! A banana peel in the middle of the road, {car.Driver} looses controll of {car.Name} but manages to take over it.");
                    Thread.Sleep(10000);

                }
                else if (accidentChance <= 8)
                {
                    Console.WriteLine($"A random bird hit the windshield, {car.Driver} quickly catches the feathers for his pillow!");
                    Thread.Sleep(5000);
                }
                else if (accidentChance <= 18)
                {
                    car.Speed -= 1;
                    Console.WriteLine($"{car.Driver} has some engine trouble with {car.Name}!" +
                        $"\nHe is currently driving at {car.Speed:F1}km/h");
                }
        }
    }
}
