Using JavaScript for MapReduce Jobs
============================
This shows a way to write MapReduce jobs using a JavaScript API

Setup
============================
Within the JavaScirpt console

	#mkdir js
	fs.put()  // put the file into the .js folder 
	runJs("js/countAndAverageDelayedFlights.js", "asv://airlinedata/", "jsFlightMR2");