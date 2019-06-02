using System;
using System.Collections.Generic;
using System.IO;

namespace Converter
{
    class Program
    {
        public static string MasterFile { get; set; }

        static void Main(string[] args)
        {
            GetFiles();
            OpenFileAndCreateList(MasterFile);
        }

        static void GetFiles()
        {
            Console.WriteLine("Please enter the master file: path/fileName: ");
            MasterFile = Console.ReadLine();
            //Console.WriteLine("Please enter the file you want to convert: path/fileName: ");
            //string fileToConv = Console.ReadLine();
            //Console.WriteLine("Please enter the location you want to save: ");
            //string savePath = Console.ReadLine();
            //Console.WriteLine("Please enter the name to save as: ");
            //string saveName = Console.ReadLine();

            //Console.WriteLine(master);
            //Console.WriteLine(fileToConv);
            //Console.WriteLine(savePath + saveName);
        }

        static List<string[]> OpenFileAndCreateList(string file)
        {
            List<string[]> fileList = new List<string[]>();

            try
            {
                foreach (string row in File.ReadAllLines(@file))
                {
                    fileList.Add(CsvParser(row));
                }
            }
            catch(Exception)
            {
                throw new InvalidOperationException("Error processing " + file + ". Make sure the directory path is correct and the file exists.");
            }

            return fileList;
        }

        static bool CheckFileHeaderNamesMatch(string master, List<string> fileToConv)
        {
            foreach(string headerName in fileToConv)
            {
                if(!master.Contains(headerName))
                {
                    return false;
                }
            }

            return true;
        }

        static string[] CsvParser(string row)
        {
            try
            {
                if (row.Contains(" "))
                {
                    return row.Split(" ");
                }
                else
                {
                    return new string[1] { row };
                }
            }
            catch(Exception)
            {
                throw new InvalidOperationException("Not able to parse row in CsvParser");
            }
            
        }
    }
}
