# A00452672_MCDA5510
Welcome to my Directory traversal program.

######Assumptions####### 
1) Any record with "," in their column is considered as a invalid record. If this condition needs to be removed, then changes need to be done in the CutomerValidator.cs file. The ".contains" section needs to be removed. 
	Then How will CSVHelper library consider the "," ?
	Answer: While writing back the record to the csv write all values with double quotes. For ex: "address,is,number 10, lake road","Halifax" will be just two records and double quotes is the delimiting value.
	
###### Path To change while executing ######

1) Change line numbers 18 and 19 in Program.Cs file file read and write path 
2) change line number 12 in LogWriter.cs for informing the location to write the log file.

Kept all the paths ie Read, write and Logging path separately to accomodate the user's mentality of usage.

##### What did I do differently ######

1) Initially created the code with Log4net library for logging the logs.
2) Wanted to learn streamwriters, so manually logging the log lines to the output log file now. ie Not using an external library.

