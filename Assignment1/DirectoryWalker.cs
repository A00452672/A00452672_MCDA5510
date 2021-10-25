using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class DirectoryWalker
    {

        public void walk(String path, LogWriter log)
        {
            string[] list = Directory.GetDirectories(path);


            if (list == null)
                return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath,log);
                }
                else
                    Console.WriteLine("The directory does not exist");
            }
            string[] fileList = Directory.GetFiles(path);
            foreach (string filepath in fileList)
            {
                if (Path.GetExtension(filepath).ToLower() == ".csv")
                {
                    Program.totalProcessedFiles++;
                    processCSV(filepath,log);
                }

            }


        }

        void processCSV(String filepath, LogWriter log)
        {
            using (var streamReader = new StreamReader(filepath))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {

                    csvReader.Context.RegisterClassMap<CutomerValidatorClassMap>();
                    while (csvReader.Read())
                    {
                        try
                        {
                            Program.totalProcessedRecords++;
                            Console.WriteLine(Program.totalProcessedRecords);
                            var record = csvReader.GetRecord<CustomerDetails>();
                            Program.totalValidRecord++;
                            Program.records.Add(record);
                        }
                        catch (FieldValidationException ex)
                        {
                            Program.totalErrorRecords++;
                            StringBuilder sb = new StringBuilder();
                            var reason = ex.Field.Equals("") ? "empty" : "Null";
                            sb.Append($"Field Validation Exception on {filepath}  " +
                                $"on Row number : {ex.Context.Parser.Row}," +
                                $"on field name : {ex.Context.Reader.HeaderRecord[ex.Context.Reader.CurrentIndex]}" +
                                $" because the field value was : {reason} ");

                            log.writeLog(sb.ToString());
                        }
                        catch (System.IO.IOException io)
                        {
                            Program.totalErrorRecords++;
                            StringBuilder sb = new StringBuilder();
                            sb.Append("IOException occured while processing the file : " + filepath);
                            sb.Append("the error trace is " + io.StackTrace);
                            log.writeLog(sb.ToString());

                        }
                        catch (Exception ex)
                        {
                            Program.totalErrorRecords++;
                            StringBuilder sb = new StringBuilder();
                            sb.Append("IOException occured while processing the file : " + filepath);
                            sb.Append("the error trace is " + ex.StackTrace);
                            log.writeLog(sb.ToString());
                        }
                    }
                }
            }
        }
    }
}
