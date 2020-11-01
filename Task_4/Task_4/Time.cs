using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4
{
    class Times
    {
        private TimeSpan time;
        public TimeSpan Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
        public TimeSpan TimePoints(string hours = "0", string minutes = "0", string seconds = "0")
        {
            string[] stringData = { hours, minutes, seconds };
            for (int i = 0; i < stringData.Length; i++)
            {
                try
                {
                    Convert.ToUInt32(stringData[i]);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Incorrect data!");
                }
            }
            Time = new TimeSpan(Convert.ToInt32(hours), Convert.ToInt32(minutes), Convert.ToInt32(seconds));
            return Time;
        }
        public TimeSpan TimeSubtraction(TimeSpan time1, TimeSpan time2)
        {
            return time1 - time2;
        }
        public TimeSpan TimeAddition(TimeSpan time1, TimeSpan time2)
        {
            return time1 + time2;
        }
        public double TimeToSeconds(TimeSpan time)
        {
            return time.TotalSeconds;
        }
        public TimeSpan ConverterToFullTime(TimeSpan time)
        {
            return time;
        }
    }
}