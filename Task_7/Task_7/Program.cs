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
                    Console.Write("Input a day: ");
                    day = Convert.ToInt32(Console.ReadLine());
                    if ((day <= 0) || (day > 31))
                    {
                        Console.WriteLine("It is only 31 days in March");
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
                    Console.WriteLine("\nChoose the weather type: \nNot defined - 0\nRain - 1\nShort rain - 2\n" +
                                        "Thunder - 3\nSnow - 4\nFog - 5\nCloudy - 6\nSunny - 7\n");
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
                    Console.Write("\nInput day temperature in " + day + " day: ");
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
                    Console.WriteLine(" ");
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
            private WeatherParametersDay[] MarchArray = new WeatherParametersDay[31];
            public void FileOrKeyboard()
            {
                string choice;
                while (true)
                {
                    try
                    {
                        Console.Write("Type 1 to enter data manually and 2 to read from file: ");
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                ReadFromKeyboard();
                                DataOutput();
                                CloudyDays();
                                DaysWithoutFallouts();
                                AverageNightTemp();
                                break;
                            case "2":
                                ReadFromFile();
                                DataOutput();
                                CloudyDays();
                                DaysWithoutFallouts();
                                AverageNightTemp();
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
                    if (numberOfRows != 31)
                    {
                        Console.WriteLine("\nMarch has 31 days.");
                    }
                    else
                    {
                        for (int i = 0; i < numberOfRows; i++)
                        {
                            WeatherParametersDay day = new WeatherParametersDay();
                            MarchArray[i] = day;
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
                for (int i = 0; i < 31; i++)
                {
                    WeatherParametersDay day = new WeatherParametersDay();
                    MarchArray[i] = day;
                    day.KeyboardInput();
                }
            }

            public void CloudyDays()
            {
                int counter = 0;
                for (int i = 0; i < 31; i++)
                {
                    if (MarchArray[i].GetWeatherKey() == 6)
                    {
                        counter++;
                    }
                }
                Console.WriteLine($"\nNumber of cloudy days: {counter}.");
            }
            public void DaysWithoutFallouts()
            {
                int counter = 0;
                for (int i = 0; i < 31; i++)
                {
                    if (MarchArray[i].GetWeatherKey() == 3 || MarchArray[i].GetWeatherKey() == 5 || MarchArray[i].GetWeatherKey() == 6 || MarchArray[i].GetWeatherKey() == 7)
                    {
                        counter++;
                    }
                }
                Console.WriteLine($"Number of days without fallouts: {counter}.");
            }
            public void AverageNightTemp()
            {
                double sumNightTemp = 0;
                double averageNightTemp;

                for (int i = 0; i < 31; i++)
                {
                    sumNightTemp += MarchArray[i].GetNightTemp();
                }
                averageNightTemp = sumNightTemp / 31;
                Console.WriteLine("Average night temperature in March: " + averageNightTemp + ".");
            }

            public void DataOutput()
            {
                Console.WriteLine("\nDay \tWeather Type \tDay temperature \tNight temperature \tAtmosphere pressure \tFallouts");
                Console.WriteLine();
                for (int i = 0; i < MarchArray.Length; i++)
                {
                    Console.WriteLine($"{MarchArray[i].GetDayNumber()}\t{MarchArray[i].GetWeather()}\t\t\t{MarchArray[i].GetDayTemp()}\t\t\t{MarchArray[i].GetNightTemp()}\t\t\t{MarchArray[i].GetAtmPressure()}\t\t\t{MarchArray[i].GetFallout()}");
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
