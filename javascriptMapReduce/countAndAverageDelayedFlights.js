var map = function (key, value, context){
	var flightData = value.split(/,/);
	var destAirport = flightData[4];
	var arrivalDelay = flightData[0];
	context.write(destAirport, arrivalDelay);
};

var reduce = function (key, values, context) {
	var flightCount = 0;
	var delaySum = 0;
	while (values.hasNext()) {
		flightCount++;
		delaySum += parseInt(values.next());
	}
	context.write(key, flightCount + "\t" + (delaySum*1.0)/(flightCount*1.0));	
};