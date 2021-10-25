using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;


public class LogWriter
{
    private static string filepath = @"C:\Users\WELCOME\Workspace\A00452672_MCDA5510\Assignment1";
    private static string logFilepath = filepath + "\\Log";
    private static string logFilename = logFilepath + "\\Log.txt";

    public LogWriter()
    {
        createLogFile();
    }

    private void createLogFile()
    {
        if (!Directory.Exists(logFilepath))
            throw new IOException();
        if (File.Exists(logFilename))
            File.Delete(logFilename);
        var myFile = File.Create(logFilename);
        myFile.Close();
    }

    public void writeLog(string logMessage)
    {
        try
        {
            using (StreamWriter w = File.AppendText(logFilename))
            {
                Log(logMessage, w);
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Unknown Error occured while writing the log file");
        }
    }

    public void Log(string logMessage, TextWriter txtWriter)
    {
        try
        {
            txtWriter.WriteLine("{0} : {1} : {2} : {3}", "DEBUG", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString(), logMessage);
        }
        catch (Exception)
        {
            Console.WriteLine("Unknown exception occured and caught gracefully");
        }
    }
}
