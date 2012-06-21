-- here is a basic pig script to read the data
-- out of the airport file and compute average delay and then order them

flights = LOAD 'fixed_flights' USING PigStorage(',') AS (arrDelayMinutes, carrier, dayOfMonth, depDelayMinutes, dest, flightDate, month, origin, rowId, year);

interestingData = FOREACH flights GENERATE dest, arrDelayMinutes;

longDelays = FILTER interestingData BY arrDelayMinutes > 30 ;

destinationGroup = GROUP longDelays BY (dest);

averages = FOREACH destinationGroup GENERATE group, COUNT(longDelays) as numberOfFlights, AVG(longDelays.arrDelayMinutes) as delay; 

busyAirports = FILTER averages BY numberOfFlights > 1000;

orderedDelays = ORDER busyAirports BY delay DESC; 

--top10 = LIMIT orderedDelays 10;

STORE orderedDelays INTO 'top10PigLongDelays' USING PigStorage(); 

 