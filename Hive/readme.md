Hive With External Tables
=============================

This shows how to create an external table using Hive pointing at Windows Azure Blob storage

Instructions 
==============================
From either the Hive console on HadoopOnAzure.com, or within the the Hive CLI on the head node (open a Hadoop command prompt and type "hive"), execute the create table script.  At that point one can run a 'show tables' and see the created table, as well as use that from within a Hive Query (some samples included)

Queries
==============================
*Basic Query*
Let's return carriers and the number of flights, and order them
	CREATE TABLE ReallyBadRoutes AS SELECT Origin, Dest, COUNT(*) as NumberOfFlights, AVG(ArrDelayMinutes) as AverageArrivalDelay  FROM airlineDelays GROUP BY Origin, Dest HAVING NumberOfFlights > 1 ORDER BY AverageArrivalDelay DESC LIMIT 100

*Top 10 most delayed routes*
	SELECT Origin, Dest, COUNT(*) as NumberOfFlights, AVG(ArrDelayMinutes) as AverageArrivalDelay  FROM airlineDelays GROUP BY Origin, Dest ORDER BY AverageArrivalDelay DESC LIMIT 10 

*Filter Out Single Instances*
	SELECT Origin, Dest, COUNT(*) as NumberOfFlightas, AVG(ArrDelayMinutes) as AverageArrivalDelay  FROM airlineDelays GROUP BY Origin, Dest HAVING NumberOfFlights > 1 ORDER BY AverageArrivalDelay DESC LIMIT 10 

*Insert Results Into New Table*
	CREATE TABLE ReallyBadRoutes AS SELECT Origin, Dest, COUNT(*) as NumberOfFlights, AVG(ArrDelayMinutes) as AverageArrivalDelay  FROM airlineDelays GROUP BY Origin, Dest HAVING NumberOfFlights > 1 ORDER BY AverageArrivalDelay DESC LIMIT 100

*Join*
Here we will do an inner join and if the route is included, we will show the difference between the average to identify carriers on the routes with the best performance relative to their peers.  This is an example of a table we may wish to precompute in its entirety to load into more of an online data warehousing system to allow for rapid query, consumption via BI tools, etc. We could simulate this by doing another CREATE TABLE AS ... as in the previous query, and then using the Hive Add in in Excel to query the data.


	SELECT airlinedelays.Origin, airlinedelays.Dest, airlinedelays.Carrier, AVG(averagearrivaldelay - airlinedelays.ArrDelayMinutes) as AvgDiffFromAverage
	FROM airlinedelays 
	JOIN reallybadroutes ON 
		(airlinedelays.Origin = reallybadroutes.Origin 
			AND 
		airlinedelays.Dest = reallybadroutes.Dest) 
	GROUP BY airlinedelays.Origin, airlinedelays.Dest, airlinedelays.Carrier 
	ORDER By AvgDiffFromAverage DESC
	LIMIT 50

**note, it was neccessary for both tables to be local, that is, not an external table when executing on HadoopOnAzure.com, I'm investigating what may be going on there.  The following queries show what is required to do there**

	CREATE TABLE airlinelocal as SELECT * FROM airlinedelays

And then the updated query:

	SELECT airlinelocal.Origin, airlinelocal.Dest, airlinelocal.Carrier, AVG(averagearrivaldelay - airlinelocal.ArrDelayMinutes) as AvgDiffFromAverage
	FROM airlinelocal 
	JOIN reallybadroutes ON 
	(airlinelocal.Origin = reallybadroutes.Origin 
	AND 
	airlinelocal.Dest = reallybadroutes.Dest) 
	GROUP BY airlinelocal.Origin, airlinelocal.Dest, airlinelocal.Carrier 
	ORDER By AvgDiffFromAverage DESC
	LIMIT 50


Resources
==============================
The Hive wiki does a good job diving through the various options available in the language: https://cwiki.apache.org/confluence/display/Hive/LanguageManual+Select