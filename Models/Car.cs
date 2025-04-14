namespace Labb_2___Threads
{
    public class Car
    {
        public string? Name { get; set; }

        public string? Driver { get; set; }
        public double Speed { get; set; } = 120;
        public double Distance { get; set; } = 0;
        public bool Finished { get; set; } = false;

        private static Random rng = new Random();

        private static object _lock = new object();

        public void Drive()
        {
            DateTime checkAccident = DateTime.Now;
            while (Distance < 5000)
            {
                Distance += Speed / 3.6;
                Thread.Sleep(1000);

                if ((DateTime.Now - checkAccident).TotalSeconds >= 10)
                {
                    checkAccident = DateTime.Now;
                    Accident();
                }
            }
            Finished = true;

            lock (_lock) 
            {
                Console.WriteLine($"\n {Driver} made the others eat the dust!");
            }
        }
        private void Announce(string message)
        {
            lock (_lock)
            {
                Console.WriteLine($"{message}");
            }
        }

        private void Accident()
        {
            int accidentChance = rng.Next(1, 51);

            if (accidentChance == 1)
            {
                Announce($"Looks like {Driver} forgot to fuel up his car!");
                Thread.Sleep(15000);
            }
            else if(accidentChance <= 3)
            {
                Announce($"OH MY GOD! A banana peel in the middle of the road, {Driver} looses controll of {Name} but manages to take over it.");
                Thread.Sleep(10000);
                
            }
            else if (accidentChance <= 8)
            {
                Announce($"A random bird hit the windshield, {Driver} quickly catches the feathers for his pillow!");
                Thread.Sleep(5000);
            }
            else if(accidentChance <= 18)
            {       
                    Speed -= 1;
                    Announce($"{Driver} has some engine trouble with {Name}!" +
                        $"\nHe is currently driving at {Speed:F1}km/h");  
            }
        }
    }
}
