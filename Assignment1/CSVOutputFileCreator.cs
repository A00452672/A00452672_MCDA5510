using Assignment1;
using CsvHelper;
using CsvHelper.Configuration;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

class CSVOutputFileCreator
{
    public static void createAndWriteOutputCsvFile(string writepath, string filename, List<CustomerDetails> records)
    {
            if (!Directory.Exists(writepath))
                Directory.CreateDirectory(writepath);
            if (File.Exists(filename))
                File.Delete(filename);
            var myFile = File.Create(filename);
            myFile.Close();
            writeDataToOutputCSV(filename, records);
    }

    private static void writeDataToOutputCSV(string filename, List<CustomerDetails> records)
    {
        var engine = new FileHelperEngine<CustomerDetails>();
        engine.HeaderText = engine.GetFileHeader();
        engine.WriteFile(filename, records);
        Console.WriteLine();
    }
}