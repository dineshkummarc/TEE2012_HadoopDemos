namespace AirlineCounterFSharp

open System
open MSDN.Hadoop.MapReduceBase

type  FlightMapper() =
    inherit MapperBaseText<Int32>()

    override self.Map (value: string) = 
        seq {
            let splits = value.Split(',')
            let destinationAirport = splits.[4]
            let arrivalDelay = Int32.Parse(splits.[0]) 
            yield (destinationAirport, arrivalDelay) 
        }


