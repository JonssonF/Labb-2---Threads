namespace Labb_2___Threads
{
    public static class CarFactory
    {
        private static List<string> randomNames = new List<string>
        {
                "Johan",
                "Gustav",
                "Petter",
                "Pär",
                "Fredrik",
                "Edgar",
                "Josef",
                "Vincent",
                "Dylan",
                "Adrian"
        };

        private static List<string> randomCar = new List<string>
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

        private static List<string> introMessages = new List<string>
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

        private static Random rng = new Random();

        public static List<Car> CreateCars(int drivers)
        {
            List<Car> cars = new List<Car>();
            for (int i = 0; i < drivers; i++)
            {
                int carIndex = rng.Next(randomCar.Count);
                int driverIndex = rng.Next(randomNames.Count);
                Car newCar = new Car
                {
                    Name = randomCar[carIndex],
                    Driver = randomNames[driverIndex]
                };
                randomNames.RemoveAt(driverIndex);
                randomCar.RemoveAt(carIndex);
                cars.Add(newCar);
            }
            return cars;
        }

        public static string GetIntroMessage(Car car)
        {
            string message = introMessages[rng.Next(0, introMessages.Count)];
            return $"{car.Driver}{message}{car.Name}";
        }
    }
}
