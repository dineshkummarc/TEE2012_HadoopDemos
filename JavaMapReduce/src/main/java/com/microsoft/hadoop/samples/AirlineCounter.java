package com.microsoft.hadoop.samples;



import org.apache.hadoop.conf.Configuration;
import org.apache.hadoop.conf.Configured;
import org.apache.hadoop.fs.Path;
import org.apache.hadoop.io.LongWritable;
import org.apache.hadoop.io.Text;
import org.apache.hadoop.mapreduce.Job;
import org.apache.hadoop.mapreduce.Mapper;
import org.apache.hadoop.mapreduce.Reducer;
import org.apache.hadoop.mapreduce.lib.input.FileInputFormat;
import org.apache.hadoop.mapreduce.lib.input.TextInputFormat;
import org.apache.hadoop.mapreduce.lib.output.FileOutputFormat;
import org.apache.hadoop.mapreduce.lib.output.TextOutputFormat;
import org.apache.hadoop.util.GenericOptionsParser;
import org.apache.hadoop.util.Tool;
import org.apache.hadoop.util.ToolRunner;


public class AirlineCounter extends Configured implements Tool 
{
	

	public static class FlightMapper extends Mapper<LongWritable, Text, Text, LongWritable>
	{
		// Operate on ArrDelayMinutes Carrier DayofMonth DepDelayMinutes Dest FlightDate Month Origin RowId Year 
		// pull out key of Destination Airport
		// value of Arrival Delay Minutes
		protected void map(LongWritable key, Text value, Context context) throws java.io.IOException ,InterruptedException
		{
			String[] flightData = value.toString().split(",");
			String destinationAirport = flightData[4];
			String arrivalDelay = flightData[0];
			context.write(new Text(destinationAirport),new LongWritable(new Long(arrivalDelay)));
		}
	}
	
	public static class FlightReducer extends Reducer<Text,LongWritable,Text, Text>
	{
		protected void reduce(Text key, java.lang.Iterable<LongWritable> values, Context context) throws java.io.IOException ,InterruptedException 
		{
			Long flightCount = new Long(0);
			Long delaySum = new Long(0); 
			for(LongWritable i: values){
				flightCount++;
				delaySum += i.get();
			}
			flightCount.toString();
			
			String s = flightCount.toString() + "\t" + (new Double(delaySum.doubleValue()/flightCount.doubleValue()).toString()) ; 
			context.write(key, new Text(s));
		}
	}
	

    public static void main(String[] args) throws Exception {
        int res = ToolRunner.run(new Configuration(), new AirlineCounter(), args);
        System.exit(res);
    }


    public int run(String[] args) throws Exception {
        String[] remainingArgs 
                = new GenericOptionsParser(getConf(), args).getRemainingArgs();
        
        if (remainingArgs.length < 2) {
            System.err.println("Usage: WorldCount <in> <out>");
            ToolRunner.printGenericCommandUsage(System.err);
            return 1;
        }
        
        Job job = new Job(getConf(), "AirlineCountert");
        job.setJarByClass(getClass());
        
        
        job.setOutputKeyClass(Text.class);
        job.setOutputValueClass(LongWritable.class);
        
        job.setMapperClass(FlightMapper.class);
        //job.setCombinerClass(IntSumReducer.class);
        job.setReducerClass(FlightReducer.class);
        
        job.setInputFormatClass(TextInputFormat.class);
        job.setOutputFormatClass(TextOutputFormat.class);

        FileInputFormat.addInputPath(job, new Path(remainingArgs[0]));
        FileOutputFormat.setOutputPath(job, new Path(remainingArgs[1]));
        
        boolean success = job.waitForCompletion(true);
        
        return success ? 0 : 1;
    }
}





