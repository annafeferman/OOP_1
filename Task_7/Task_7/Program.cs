using System;
using System.IO;

namespace Task_7
{
    class WeatherParametersDay
    {
        enum WeatherTypes
        {
            NotDefined = 0,
            Rain = 1,
            ShortRain = 2,
            Thunder = 3,
            Snow = 4,
            Fog = 5,
            Cloudy = 6,
            Sunny = 7
        }
        private int day;
        private double averageDayTemp;
        private double averageNightTemp;
        private double averagePressure;
        private double fallout;
        private int weatherType;

        public void KeyboardInput()
        {
            while (true)
            {
                try
                {
                    Console.Write("\nInput a day: ");
                    day = Convert.ToInt32(Console.ReadLine());
                    if ((day <= 0) || (day > 28))
                    {
                        Console.WriteLine("It is only 28 days in February");
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Choose the weather type: \nНе визначено - 0\nДощ - 1\nКороткочасний дощ - 2\n" +
                                        "Гроза - 3\nСніг - 4\nТуман - 5\nПохмуро - 6\nСонячно - 7\n");
                    weatherType = Convert.ToInt32(Console.ReadLine());
                    if (weatherType > 1 | weatherType < 7)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Choose the number between 1 and 7");
                        Console.WriteLine(" ");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Input day temperature in " + day + " day: ");
                    averageDayTemp = Convert.ToDouble(Console.ReadLine());
                    if ((averageDayTemp < -20) || (averageDayTemp > 60))
                    {
                        Console.WriteLine("Probably, you've input wrong remperature");
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Input night temperature in " + day + " day: ");
                    averageNightTemp = Convert.ToDouble(Console.ReadLine());
                    if ((averageNightTemp < -20) || (averageNightTemp > 60))
                    {
                        Console.WriteLine("Probably, you've input wrong remperature");
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Input average atm.Pressure in " + day + " day: ");
                    averagePressure = Convert.ToDouble(Console.ReadLine());
                    if ((averagePressure < 500) || (averagePressure > 1000))
                    {
                        Console.WriteLine("Probably, you've input the wrong atmosphere pressure");
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Input average fallout in " + day + " day: ");
                    fallout = Convert.ToDouble(Console.ReadLine());
                    if ((fallout < 0) || (fallout > 1000))
                    {
                        Console.WriteLine("Probably, you've input the wrong fallout quantity");
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void FileDataReading(StreamReader streamReader)
        {
            string line = streamReader.ReadLine();
            string[] data = line.Split(',');

            if (data.Length != 6)
            {
                Console.WriteLine("\nThere must be 6 parameters. Check your file data again.\n");
            }
            else
            {
                try
                {
                    day = Convert.ToInt32(data[0]);
                    weatherType = Convert.ToInt32(data[1]);
                    averageDayTemp = Convert.ToDouble(data[2]);
                    averageNightTemp = Convert.ToDouble(data[3]);
                    averagePressure = Convert.ToDouble(data[4]);
                    fallout = Convert.ToDouble(data[5]);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public int GetDayNumber()
        {
            return day;
        }
        public object GetWeather()
        {
            return (WeatherTypes)weatherType;
        }

        public int GetWeatherKey()
        {
            return weatherType;
        }

        public double GetDayTemp()
        {
            return averageDayTemp;
        }

        public double GetNightTemp()
        {
            return averageNightTemp;
        }

        public double GetAtmPressure()
        {
            return averagePressure;
        }

        public double GetFallout()
        {
            return fallout;
        }
        public class WeatherDays
        {
            private WeatherParametersDay[] FebruaryArray = new WeatherParametersDay[28];
            public void FileOrKeyboard()
            {
                string choice;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Type 1 to enter data manually and 2 to read from file: ");
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                ReadFromKeyboard();
                                DataOutput();
                                SunnyDays();
                                RainAndThunder();
                                MinMaxNightTemp();
                                break;
                            case "2":
                                ReadFromFile();
                                DataOutput();
                                SunnyDays();
                                RainAndThunder();
                                MinMaxNightTemp();
                                break;
                            default:
                                Console.WriteLine("Input only 1 or 2");
                                continue;
                        }
                        break;

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Input only 1 or 2");
                    }
                }
            }
            public void ReadFromFile()
            {
                string path = @"..\weather_data.txt";
                try
                {
                    StreamReader sr = new StreamReader(path);
                    int count = 0;
                    foreach (string i in File.ReadAllLines(path))
                    {
                        count++;
                    }
                    int numberOfRows = count;
                    if (numberOfRows != 28)
                    {
                        Console.WriteLine("\nFebruary has 28 days.");
                    }
                    else
                    {
                        for (int i = 0; i < numberOfRows; i++)
                        {
                            WeatherParametersDay day = new WeatherParametersDay();
                            FebruaryArray[i] = day;
                            day.FileDataReading(sr);
                        }
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            public void ReadFromKeyboard()
            {
                for (int i = 0; i < 28; i++)
                {
                    WeatherParametersDay day = new WeatherParametersDay();
                    FebruaryArray[i] = day;
                    day.KeyboardInput();
                }
            }

            public void SunnyDays()
            {
                int counter = 0;
                for (int i = 0; i < 28; i++)
                {
                    if (FebruaryArray[i].GetWeatherKey() == 7)
                    {
                        counter++;
                    }
                }
                Console.WriteLine($"\nNumber of sunny days: {counter}.");
            }
            public void RainAndThunder()
            {
                int counter = 0;
                for (int i = 0; i < 31; i++)
                {
                    if (FebruaryArray[i].GetWeatherKey() == 1 || FebruaryArray[i].GetWeatherKey() == 2 || FebruaryArray[i].GetWeatherKey() == 3)
                    {
                        counter++;
                    }
                }
                Console.WriteLine($"\nNumber of days with rain or thunder: {counter}.");
            }
            public void MinMaxNightTemp()
            {
                double min = 100;
                double max = -100;

                for (int i = 0; i < 28; i++)
                {
                    if (FebruaryArray[i].GetDayTemp() <= min)
                    {
                        min = FebruaryArray[i].GetDayTemp();
                    }
                    if (FebruaryArray[i].GetDayTemp() >= max)
                    {
                        max = FebruaryArray[i].GetDayTemp();
                    }
                }
                Console.WriteLine("Maximal day temperature in February: " + max);
                Console.WriteLine("Minimal day temperature in February: " + min);
            }

            public void DataOutput()
            {
                Console.WriteLine("\nДень \tТип погоди \tДенна темп-ра (C) \tНічна темп-ра (C) \tАтмосферний тиск \tКількість опадів");
                Console.WriteLine();
                for (int i = 0; i < FebruaryArray.Length; i++)
                {
                    Console.WriteLine($"{FebruaryArray[i].GetDayNumber()}\t{FebruaryArray[i].GetWeather()}\t\t\t{FebruaryArray[i].GetDayTemp()}\t\t\t{FebruaryArray[i].GetNightTemp()}\t\t\t{FebruaryArray[i].GetAtmPressure()}\t\t\t{FebruaryArray[i].GetFallout()}");
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                WeatherDays july = new WeatherDays();
                july.FileOrKeyboard();

                Console.ReadKey();
            }
        }
    }
}
