Basic Streaming
======================

This is a sample of basic map reduce based streaming using the streaming jar.

Streaming i

Build Instructions
======================
Build projects in VS

or

	msbuild basicNetStreaming.sln 

should do the trick

Execution Instructions
======================
From a Hadoop command prompt (note, this assumes that %HADOOP_HOME% is defined, the streaming jar has been built, and a full path to the executables:

	hadoop jar %HADOOP_HOME%\lib\hadoop-streaming.jar -mapper f:\dev\src\csharp\hadoopdebugger\GenerateAirlineKeyMapper\bin\Debug\GenerateAirlineKeyMapper.exe -reducer f:\dev\src\csharp\hadoopdebugger\AirlineFlightCountReducer\bin\Debug\AirlineFlightCountReducer.exe -input fixed_flights -output test_streaming
	