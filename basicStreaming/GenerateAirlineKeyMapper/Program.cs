using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateAirlineKeyMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                // format:
                // ArrDelayMinutes,Carrier,DayofMonth,DepDelayMinutes,Dest,FlightDate,Month,Origin,RowId,Year
                string[] splits = line.Split(',');
                
                Console.WriteLine(splits[1] + "\t" + line);
            }
        }
    }
}
