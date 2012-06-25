.NET Map Reduce
===========================

This is a sample leveraging the sample library from the upcoming .NET SDK for Hadoop.  

There is a nuget package reference which will grab the appropriate assemblies.  To execute:

	MSDN.Hadoop.Submission.Console.exe -input fixed_flights -output outputCsharpFlights23 -mapper "AirlineCounter.AirlineCountMapper, AirlineCounter" -reducer "AirlineCounter.AirlineCountReducer, AirlineCounter" -file .\AirlineCounter.dll