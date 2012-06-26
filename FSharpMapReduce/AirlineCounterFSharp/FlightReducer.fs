namespace AirlineCounterFSharp

open System
open MSDN.Hadoop.MapReduceBase

type  FlightReducer() =
    inherit ReducerBase<Int32, string>()

    override self.Reduce (key:string) (values:seq<Int32>) = 
        Seq.singleton (key, (values |> Seq.length).ToString())
