CREATE EXTERNAL TABLE airlineDelays
	(ArrDelayMinutes INT,
	 Carrier STRING,
	 DayofMonth INT,
	 DepDelayMinutes INT,
	 Dest STRING,
	 FlightDate STRING,
	 Month INT,
	 Origin STRING,
	 RowId STRING, 
	 Year INT)
 COMMENT 'This is an external table created on top of the text file'
 ROW FORMAT DELIMITED FIELDS TERMINATED BY ','
 STORED AS TEXTFILE
 LOCATION 'asv://airlinedata/'