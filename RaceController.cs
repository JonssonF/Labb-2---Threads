using System.Threading;

namespace Labb_2___Threads
{
    public class RaceController
    {
        static List<Car> cars = new List<Car>();
        static List<Thread> threads = new List<Thread>();
        static bool raceFinished = false;
        static Car winner = null;
        static Random rng = new Random();

        public static void AppRun()
        {
            Presentation();
            Race();
            //Finished();
        }

        public static void Presentation()
        {
            Console.WriteLine("Welcome to Freddys Fast & Furious Forloop's Race!\n");
            Thread.Sleep(2000);
            Console.WriteLine("How many cars should race? (1-9).");
            int drivers = int.Parse(Console.ReadLine());
            drivers = Math.Clamp(drivers, 1, 9);

            if (drivers < 1 || drivers > 9)
            {
                Console.WriteLine("Invalid number of cars. Please enter a number between 1 and 9.");
                return;
            }
            Console.WriteLine("The cars are getting ready to drive.\n");
            Thread.Sleep(2000);

            List<string> randomNames = new List<string>
            {
                "Johan",
                "Gustav",
                "Petter",
                "Lina",
                "Edgar",
                "Josef",
                "Vincent",
                "Dylan",
                "Adrian" };

            List<string> randomCar = new List<string>
            {
                "FreeBird",
                "The Batmobile",
                "MustangSally",
                "Fårrden",
                "Old Faithful",
                "K.I.T.T",
                "Optimus Prime",
                "740'n",
                "BumbleBee"
            };

            for (int i = 0; i < drivers; i++)
            {
                int carIndex = rng.Next(randomCar.Count);
                int driverIndex = rng.Next(randomNames.Count);

                Car newCar = new Car
                {
                    Name = randomCar[carIndex],
                    Driver = randomNames[driverIndex]
                };
                   //if (newCar.Driver == "Josef") 
                   //{
                   // newCar.Name = "Bicycle";
                   //}

                randomNames.RemoveAt(driverIndex);
                randomCar.RemoveAt(carIndex);

                cars.Add(newCar);
            }

            List<string> introMessages = new List<string>
            {
                " is focused behind the wheel of ",
                " grips the wheel tightly in ",
                " takes a deep breath in ",
                " checks the mirrors in ",
                " revs the engine of ",
                " adjusts the seat in ",
                " cracks their knuckles inside of ",
                " squints toward the road in ",
                " taps the gas pedal of ",
                " is ready to speed off in "
            };

            foreach (Car car in cars)
            {
                string message = introMessages[rng.Next(0, introMessages.Count)];
                Console.WriteLine($"{car.Driver}{message}{car.Name}!\n");
                Thread.Sleep(500);
            }

            string countdown = "321";

            foreach (char c in countdown)
            {
                Console.Write($"{c} ");
                Thread.Sleep(1000);
            }
            Console.WriteLine("\n..::GO!::..");



            new Thread(() =>
            {
                while (true)
                {
                    var input = Console.ReadLine();

                    if (input?.ToLower() == "status" || string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("\n ..::STATUS REPPORT::..");
                        foreach (Car car in cars)
                        {
                            Console.WriteLine($"{car.Driver} is driving {car.Name} at {car.Distance:F1} meters in {car.Speed:F1}km/h.");
                        }
                        Console.WriteLine();
                    }
                }
            }).Start();

            foreach (var thread in threads)
            {
                thread.Join();
            }

        }
        public static void Race()
        {
            foreach (Car car in cars)
            {
                Thread thread = new Thread(car.Drive);
                threads.Add(thread);
                thread.Start();
            }
        }

    }
}
