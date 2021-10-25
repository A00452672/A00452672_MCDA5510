using Assignment1;
using CsvHelper;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

class Program
{
    public static int totalErrorRecords = 0;
    public static int totalProcessedFiles = 0;
    public static int totalValidRecord = 0;
    public static int totalProcessedRecords = 0;
    public static List<CustomerDetails> records = new List<CustomerDetails>();
    public static string readpath = @"C:\Users\WELCOME\source\repos\A00452672_MCDA5510\Assignment1\Sample Data-full";
    public static string writepath = @"C:\Users\WELCOME\Workspace\A00452672_MCDA5510\Assignment1\Output";
    public static string filename = writepath + "\\Output.csv";

    static void Main()
    {
        try
        {
            DirectoryWalker directoryTraverser = new DirectoryWalker();
            LogWriter log = new LogWriter();
            Stopwatch stopWatch = new Stopwatch();
            if (File.Exists(filename))
                File.Delete(filename);
            stopWatch.Start();
            directoryTraverser.walk(readpath,log);
            stopWatch.Stop();
            TimeSpan timeSpan = stopWatch.Elapsed;
            CSVOutputFileCreator.createAndWriteOutputCsvFile(writepath, filename, records);
            log.writeLog("\nTotal Processed Files are : " + totalProcessedFiles + "\nTotal Valid Records are : " + totalValidRecord + "" +
                "\nTotal Processed Records are : " + totalProcessedRecords + "\nTotal Error Records are : " + totalErrorRecords +
                "\nTotal Time taken for processing : " + timeSpan);

        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file or directory cannot be found.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The file or directory cannot be found.");
        }
        catch (DriveNotFoundException)
        {
            Console.WriteLine("The drive specified in 'path' is invalid.");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("'path' exceeds the maxium supported path length.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You do not have permission to create this file.");
        }

        catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
        {
            Console.WriteLine("There is a sharing violation.");
        }
        catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
        {
            Console.WriteLine("The file already exists.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"An exception occurred:\nError code: " +
                              $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
        }

        catch (Exception ex)
        {
            Console.WriteLine("Unknown Exception occured" + ex.Message);
        }

    }
}