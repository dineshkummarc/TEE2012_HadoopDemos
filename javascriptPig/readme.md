JavaScript Pig
=====================

This uses the JavaScript console on http://www.hadooponazure.com in order to execute a job.

This job assumes that you have copied the flight data into an Azure blob store (ideally located in NorthCentral-US) and mounted that as an asv volume using the HadoopOnAzure manage tab.

This is a basic wrapper which builds the proper Pig script, in this case to compute the top 10 most delayed flights. 