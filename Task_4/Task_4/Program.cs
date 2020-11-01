using System;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your frist timepoint: \n");

            Console.Write("Hours: ");
            string hours = Console.ReadLine();
            Console.Write("Minutes: ");
            string minutes = Console.ReadLine();
            Console.Write("Seconds: ");
            string seconds = Console.ReadLine();
            Console.WriteLine(" ");

            Times times = new Times();
            TimeSpan timespan_1 = times.TimePoints(hours, minutes, seconds);

            Console.WriteLine("Second timepoint: ");

            Console.Write("Hours: ");
            string hours_2 = Console.ReadLine();
            Console.Write("Minutes: ");
            string minutes_2 = Console.ReadLine();
            Console.Write("Seconds: ");
            string seconds_2 = Console.ReadLine();

            Console.WriteLine(" ");
            Console.WriteLine("Timepoint in seconds: ");

            string TimeSeconds = Console.ReadLine();
            TimeSpan timespan_sec = times.TimePoints(seconds: TimeSeconds);

            TimeSpan timespan_2 = times.TimePoints(hours_2, minutes_2, seconds_2);

            Console.WriteLine(" ");
            Console.WriteLine($"Timepoints addition: {times.TimeAddition(timespan_1, timespan_2)}");
            Console.WriteLine($"Timepoints substraction: {times.TimeSubtraction(timespan_1, timespan_2)}");
            Console.WriteLine($"First timepoint in seconds: {times.TimeToSeconds(timespan_1)}");
            Console.WriteLine($"Second timepoint in seconds: {times.TimeToSeconds(timespan_2)}");

            Console.WriteLine($"Full time from seconds: {times.ConverterToFullTime(timespan_sec)}");
        }
    }
}