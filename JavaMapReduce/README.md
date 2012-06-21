Java Map Reduce
===================

This shows a basic Java Map Reduce operating over a set of flight delay information to compute the set of airports, total number of delayed flights, and the average duration of the delay.

Build Instructions
===================
mvn package

Execution Instructions
===================
hadoop jar airlineCount-1.0-SNAPSHOT.jar com.microsoft.hadoop.samples.AirlineCounter input_flights flight_output