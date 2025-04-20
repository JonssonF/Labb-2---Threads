using Labb_2___Threads.UI;
using System.Threading;

namespace Labb_2___Threads
{
    public class RaceController
    {
        static List<Car> cars = new List<Car>();
        static List<Thread> threads = new List<Thread>();

        
        public static void AppRun()
        {
            Presentation();
            Race();
            //Finished();
        }

        //Presentation of the Application.
        public static void Presentation()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Welcome to Freddys Fast & Furious Forloop's Race!\uD83D\uDE97\n");
            Thread.Sleep(2000);

            int drivers = 0;
            bool validInput = false;

            // Loop until valid input is received.
            while (!validInput)
            {
                Console.WriteLine("How many drivers are racing? (2-9)");
                string input = Console.ReadLine();

                if (int.TryParse(input, out drivers) && drivers >= 2 && drivers <= 9)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 2 and 9.");
                }
            }
            Console.WriteLine("The cars are getting ready to drive.\n");
            Thread.Sleep(2000);

            // Create drivers and cars
            cars = CarFactory.CreateCars(drivers);

            // Display random intro messages for each driver.
            foreach (Car car in cars)
            {
                Console.WriteLine(CarFactory.GetIntroMessage(car));
                Console.WriteLine();
                Thread.Sleep(1000);
            }
                Thread.Sleep(1000);
            Console.WriteLine("\nDRIVERS GET READY!");
                Thread.Sleep(1000);

            string countdown = "321";

            foreach (char c in countdown)
            {
                Console.Write($"{c} ");
                Thread.Sleep(1000);
            }

            RaceUI.RaceASCII();

            // New thread that presents current status of our drivers.
            new Thread(() =>
            {   
                while (true)
                {
                    var input = Console.ReadLine();

                    if (input?.ToLower() == "status" || string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine($"\n ..::STATUS REPPORT::....::Elapsed Time: {Car.raceTimer.Elapsed.TotalSeconds:F1} seconds::..");
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

        //Method that starts the race in a separate thread for each car
        //All car objects runs the 'Drive' method from class Car.cs
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
