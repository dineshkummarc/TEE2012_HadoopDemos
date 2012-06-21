Basic Pig Sample
====================

This sample demonstrates the use of Pig to grovel over the data.

It assumes the flights data exists in "fixed_flights" and will output to 

Execution Instructions
====================

	pig -f computeAirportDelays.pig 


Advanced Pig
=====================
This sample uses a nested foreach in order to compute the top 3 most delayed flights into  the destination airports with the 10 highest average delays

Execution Instructions
====================

	pig -f advancedPig.pig 