F# Map/Reduce
=========================
Similar example to the C# Map/Reduce 


Execution
=========================
	
	F:\dev\src\github\TEE2012_HadoopDemos>MSDN.Hadoop.Submission.Console.exe -input fixed_flights -output outputFsharpFlights -mapper "AirlineCounterFSharp.FlightMapper, AirlineCounterFSharp" -reducer "AirlineCounterFSharp.FlightReducer, AirlineCounterFSharp" -file .\AirlineCounterFSharp.dll