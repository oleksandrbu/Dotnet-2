using System;

public enum Months
{
    Empty = 0, January = 1, February, March, April, May, June, July, August, September, October, November, December
}  

namespace Dotnet_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Calendar(Months.June);
            Calendar(Months.August);
        }
        public static void Calendar(Months month = (Months) 0, int year = -1)
        {
            DateTime[] holidays = { new DateTime(2020, 8, 5), new DateTime(2020, 8, 24)};
            DateTime currentDay = new DateTime((int) DateTime.Now.Year, (int) DateTime.Now.Month, (int) DateTime.Now.Day);
            DateTime day1;
            if (year == -1){
                year = DateTime.Now.Year;
            }
            if (month == Months.Empty){
                month = (Months) DateTime.Now.Month;
            } 
            day1 = new DateTime((int) year, (int) month, (int) 1);
            uint count = 0, k = 0;

            Console.WriteLine("Mo Tu We Th Fr \x1b[31mSa\x1b[0m \x1b[31mSu\x1b[0m");
            for (int i = 0; i < (int) day1.DayOfWeek - 1; i++){
                Console.Write("   ");
            }
            for (int i = 1; i <= DateTime.DaysInMonth(currentDay.Year, currentDay.Month); i++){
                if (day1.CompareTo(currentDay) == 0){
                    Console.Write("\x1b[34m{0:d2}\x1b[0m ", i);
                } else {
                    switch((int) day1.DayOfWeek){
                    case 0:
                        Console.Write("\x1b[31m{0:d2}\x1b[0m ", i);
                        Console.WriteLine("");
                        break;
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
			            for(int j = 0; j < holidays.Length; j++){
                            if (holidays[j].CompareTo(day1) == 0){
                                k = 1;      
                            }
                        }
                        if (k == 1){
                            Console.Write("\x1b[31m{0:d2}\x1b[0m ", i);
                            k = 0;
                        } else {
                            Console.Write("\x1b[37m{0:d2}\x1b[0m ", i);
                        }
                        break;
                    case 6:
			            Console.Write("\x1b[31m{0:d2}\x1b[0m ", i);
                        break;
                    default:
                        break;
                    }
                }
                day1 = day1.AddDays(1);
            }
            Console.WriteLine("");
        }
    }
}
