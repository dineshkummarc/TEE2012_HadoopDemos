using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineFlightCountReducer
{
    class Program
    {
        static void Main(string[] args)
        {
            // inbound looks like Airline \t 
            // // ArrDelayMinutes,Carrier,DayofMonth,DepDelayMinutes,Dest,FlightDate,Month,Origin,RowId,Year
            string line;
            string oldLine = string.Empty;
            int count = 0;
            int minArrDelay = 0;
            int maxArrDelay = 0;
            int minDepDelay = 0;
            int maxDepDelay = 0; 

            while ((line = Console.ReadLine()) != null)
            {

                if ((oldLine == line.Split('\t')[0]) || (oldLine == string.Empty))
                {
                    string[] flightRecord = line.Split('\t')[1].Split(',');
                    minArrDelay = Math.Min(Int32.Parse(flightRecord[9]), 2012);
                    maxArrDelay = Math.Max(Int32.Parse(flightRecord[0]), maxArrDelay);
                    minDepDelay = Math.Min(Int32.Parse(flightRecord[3]), minDepDelay);
                    maxDepDelay = Math.Max(Int32.Parse(flightRecord[3]), maxDepDelay); 
                    count++;
                }
                else
                {
                    // switching it up
                    Console.WriteLine(oldLine.Split('\t')[0] + "\t" + count + "," + minArrDelay + "," + maxArrDelay + "," + minDepDelay + "," + maxDepDelay);
                    count = 1;
                    minArrDelay = 0;
                    maxArrDelay = 0;
                    minDepDelay = 0;
                    maxDepDelay = 0; 
                }
                oldLine = line.Split('\t')[0]; 
                
            }
            // and get the last one
            Console.WriteLine(oldLine.Split('\t')[0] + "\t" + count + "," + minArrDelay + "," + maxArrDelay + "," + minDepDelay + "," + maxDepDelay); 
        }
    }
}
