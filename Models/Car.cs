using Labb_2___Threads.Models;
using System.Diagnostics;

namespace Labb_2___Threads
{
    public class Car
    {
        public string? Name { get; set; }

        public string? Driver { get; set; }
        public double Speed { get; set; } = 120;
        public double Distance { get; set; } = 0;
        public bool Finished { get; set; } = false;

        private static object _lock = new object();

        private static int trophy = 1;

        public static Stopwatch raceTimer = new Stopwatch();

        //Method to simulate driving logic.
        public void Drive()
        {

            lock (_lock)
            {
                if (!raceTimer.IsRunning)
                {
                    raceTimer.Start();
                }
            }

            //Saves the current time to check for accidents
            DateTime checkAccident = DateTime.Now;
            while (Distance < 5000)
            {// ÄNDRA DISTANCE TILL 5000 när tester är färdiga.
                Distance += Speed / 3.6;
                Thread.Sleep(1000);

                if ((DateTime.Now - checkAccident).TotalSeconds >= 10)
                {
                    checkAccident = DateTime.Now;
                    AccidentManager.Accident(this);
                }
            }

            Finished = true;
            lock (_lock)
            {
                if (trophy == 1)
                {
                    Console.WriteLine("WE HAVE A WINNER!!\n");
                    Console.WriteLine($"{Driver} finished the race at {trophy} place in {raceTimer.Elapsed.TotalSeconds:F1} seconds!");
                }
                else
                {
                    Console.WriteLine($"\n {Driver} finished the race at {trophy} place in {raceTimer.Elapsed.TotalSeconds:F1} seconds!");
                }
                trophy++;
            }
        }
    }
}
