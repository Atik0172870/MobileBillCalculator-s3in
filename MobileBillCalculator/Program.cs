using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBillCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Call Start Time: ");
            string startTime = Console.ReadLine();

            Console.WriteLine("Call End Time: ");
            string endTime = Console.ReadLine();

            DateTime startTime1DayFormat = DateTime.Parse(DateTime.Parse(startTime).ToString("HH:mm:ss"));
            DateTime endTime1DayFormat = DateTime.Parse(DateTime.Parse(endTime).ToString("HH:mm:ss"));

            if (startTime1DayFormat > endTime1DayFormat)
            {
                endTime1DayFormat = endTime1DayFormat.AddDays(1);
            }

            double totalCosting = 0;
            double totalCostInTaka = 0;

            while (startTime1DayFormat <= endTime1DayFormat)
            {
                //startTime1DayFormat = startTime1DayFormat.AddSeconds(20);

                if (PeekHourChecker(startTime1DayFormat))
                {
                    var PreviousTime = startTime1DayFormat; 
                    startTime1DayFormat = startTime1DayFormat.AddSeconds(20);
                    totalCosting += 30;

                    var diffInSeconds="";
                    if(startTime1DayFormat> endTime1DayFormat)
                    {
                        diffInSeconds = ((endTime1DayFormat - PreviousTime).TotalSeconds).ToString();
                        Console.WriteLine(PreviousTime + " + " + diffInSeconds + " second " + "(" + endTime1DayFormat + ")" + " = 30 paisa");
                    }
                    else
                    {
                        diffInSeconds = ((startTime1DayFormat - PreviousTime).TotalSeconds).ToString();
                        Console.WriteLine(PreviousTime + " + " + diffInSeconds + " second " + "(" + startTime1DayFormat + ")" + " = 30 paisa");
                    }
                    
                    //Console.WriteLine(PreviousTime+" + "+diffInSeconds + " second "+"("+ startTime1DayFormat + ")" + " = 30 paisa");

                }
                else
                {
                    var PreviousTime = startTime1DayFormat;

                    startTime1DayFormat = startTime1DayFormat.AddSeconds(20);
                    totalCosting += 20;

                    var diffInSeconds = "";
                    if (startTime1DayFormat > endTime1DayFormat)
                    {
                        diffInSeconds = ((endTime1DayFormat - PreviousTime).TotalSeconds).ToString();
                        Console.WriteLine(PreviousTime + " + " + diffInSeconds + " second " + "(" + endTime1DayFormat + ")" + " = 20 paisa");
                    }
                    else
                    {
                        diffInSeconds = ((startTime1DayFormat - PreviousTime).TotalSeconds).ToString();
                        Console.WriteLine(PreviousTime + " + " + diffInSeconds + " second " + "(" + startTime1DayFormat + ")" + " = 20 paisa");
                    }
                    //Console.WriteLine(PreviousTime + " + " + diffInSeconds + " second " + "(" + startTime1DayFormat + ")" + " = 20 paisa");
                }
            }
            totalCostInTaka = totalCosting / 100.00;

            Console.WriteLine("Total Costing " + totalCostInTaka + " taka");
            Console.ReadKey();
        }
        static bool PeekHourChecker(DateTime requiredTime)
        {
            DateTime peekHourStartTime = DateTime.Parse(DateTime.Parse("9:00:00 am").ToString("HH:mm:ss"));
            DateTime peekHourEndTime = DateTime.Parse(DateTime.Parse("10:59:59 pm").ToString("HH:mm:ss"));
            if ((requiredTime >= peekHourStartTime && requiredTime <= peekHourEndTime) || requiredTime.AddSeconds(20) >= peekHourStartTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
