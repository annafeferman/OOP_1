using System;

namespace time
{

    class Time
    {
        private UInt64 seconds;
        private UInt64 minutes;
        private UInt64 hours;
        public UInt64 GetSeconds()
        {
            return this.seconds;
        }

        public void SetSeconds(UInt64 seconds)
        {
            this.seconds = seconds;
        }

        public UInt64 GetMinutes()
        {
            return this.minutes;
        }
        public void SetMinutes(UInt64 minutes)
        {
            this.minutes = minutes;
        }
        public UInt64 GetHours()
        {
            return this.hours;
        }
        public void SetHours(UInt64 hours)
        {
            this.hours = hours;
        }
        public static void AddTime(Time firstTime, Time secondTime)
        {
            Time resultTimeAdd = new Time();
            UInt64 leftByMins;
            UInt64 leftBySec;
            UInt64 hoursIncreasing;
            UInt64 minutesIncreasing;
            resultTimeAdd.SetHours(firstTime.GetHours() + secondTime.GetHours());
            resultTimeAdd.SetMinutes(firstTime.GetMinutes() + secondTime.GetMinutes());
            resultTimeAdd.SetSeconds(firstTime.GetSeconds() + secondTime.GetSeconds());
            leftByMins = resultTimeAdd.GetMinutes() % 60;
            leftBySec = resultTimeAdd.GetSeconds() % 60;
            hoursIncreasing = resultTimeAdd.GetMinutes() / 60;
            minutesIncreasing = resultTimeAdd.GetSeconds() / 60;
            if (resultTimeAdd.GetMinutes() > 60)
            {
                resultTimeAdd.SetHours(resultTimeAdd.GetHours() + hoursIncreasing);
                resultTimeAdd.SetMinutes(leftByMins);
            }
            if (resultTimeAdd.GetSeconds() > 60)
            {
                resultTimeAdd.SetMinutes(resultTimeAdd.GetMinutes() + minutesIncreasing);
                resultTimeAdd.SetSeconds(leftBySec);
            }
            Console.WriteLine("Addition result: " + resultTimeAdd.GetHours() + ":" + resultTimeAdd.GetMinutes() + ":" + resultTimeAdd.GetSeconds());
        }
        public static void SubstractTime(Time firstTime, Time secondTime)
        {
            Time resultTimeSub = new Time();

            if (firstTime.GetHours() < secondTime.GetHours())
            {
                Console.WriteLine("First time is smaller than the second");
                return;
            }
            else
            {
                resultTimeSub.SetHours(firstTime.GetHours() - secondTime.GetHours());
            }
            if (firstTime.GetMinutes() < secondTime.GetMinutes())
            {
                Console.WriteLine("First time is smaller than the second");
                return;
            }
            else
            {
                resultTimeSub.SetMinutes(firstTime.GetMinutes() - secondTime.GetMinutes());
            }
            if (firstTime.GetSeconds() < secondTime.GetSeconds())
            {
                Console.WriteLine("First time is smaller than the second");
                return;
            }
            else
            {
                resultTimeSub.SetSeconds(firstTime.GetSeconds() - secondTime.GetSeconds());
            
            }
              Console.WriteLine("Substraction result: " + resultTimeSub.GetHours() + ":" + resultTimeSub.GetMinutes() + ":" + resultTimeSub.GetSeconds());
        }
        public static void InputValues(Time firstTime, Time secondTime)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Input first quantity of hours:");
                    firstTime.SetHours(Convert.ToUInt64(Console.ReadLine()));
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Input first quantity of minutes:");
                    firstTime.SetMinutes(Convert.ToUInt64(Console.ReadLine()));
                    if (firstTime.GetMinutes() > 60) { throw new Exception(); }
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Minutes are out of range");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Input first quantity of seconds:");
                    firstTime.SetSeconds(Convert.ToUInt64(Console.ReadLine()));
                    if (firstTime.GetSeconds() > 60) { throw new ArgumentException(); }
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Seconds are out of range");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(" ");
            OutputValues(firstTime);
            Console.WriteLine(" ");
            while (true)
            {
                try
                {
                    Console.WriteLine("Input second quantity of hours");
                    secondTime.SetHours(Convert.ToUInt64(Console.ReadLine()));
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Input second quantity of minutes");
                    secondTime.SetMinutes(Convert.ToUInt64(Console.ReadLine()));
                    if (secondTime.GetMinutes() > 60) { throw new ArgumentException(); }
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Minutes out of range");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Input second quantity of seconds");
                    secondTime.SetSeconds(Convert.ToUInt64(Console.ReadLine()));
                    if (secondTime.GetSeconds() > 60) { throw new ArgumentException(); }
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Seconds out of range");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine(" ");
            OutputValues(secondTime);
            Console.WriteLine(" ");
        }
        public static void FirstTimeToSeconds(Time firstTime)
        {
            UInt64 resultTimeToSeconds = 0;
            resultTimeToSeconds += firstTime.GetHours() * 3600 + firstTime.GetMinutes() * 60 + firstTime.GetSeconds();
            Console.WriteLine("First time in seconds: " + resultTimeToSeconds);
        }

        public static void SecondTimeToSeconds(Time secondTime)
        {
            UInt64 resultTimeToSeconds = 0;
            resultTimeToSeconds += secondTime.GetHours() * 3600 + secondTime.GetMinutes() * 60 + secondTime.GetSeconds();
            Console.WriteLine("Second time in seconds: " + resultTimeToSeconds);
        }

        private static void OutputValues(Time time)
        {
            Console.WriteLine("Your time: ");
            Console.WriteLine(time.GetHours() + ":" + time.GetMinutes() + ":" + time.GetSeconds());
        }


    }
    class Program
    {

        private static Time firstTime;
        private static Time secondTime;
        private static Time resultTimeAdd;

        static void Main(string[] args)
        {
            initVariables();

            Time.InputValues(firstTime,secondTime);
            Time.AddTime(firstTime, secondTime);
            //Time.TimeToCanonical(resultTimeAdd);
            Time.SubstractTime(firstTime, secondTime);
            
            Time.FirstTimeToSeconds(firstTime);
            Time.SecondTimeToSeconds(secondTime);
        }
        private static void initVariables()
        {
            firstTime = new Time();
            secondTime = new Time();
            resultTimeAdd = new Time();
        }
    }
}
