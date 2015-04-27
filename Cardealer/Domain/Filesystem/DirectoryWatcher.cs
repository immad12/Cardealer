using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Domain.Filesystem
{
    class DirectoryWatcher
    {
        static FileSystemWatcher watcher;

        public DirectoryWatcher()
        {
            // Establish the path to the directory to watch.
            watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = @"C:\MyFolder";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            // Set up the things to be on the lookout for.
            watcher.NotifyFilter = NotifyFilters.LastAccess
              | NotifyFilters.LastWrite
              | NotifyFilters.FileName
              | NotifyFilters.Size
              | NotifyFilters.DirectoryName;

            // Only watch text files.
            watcher.Filter = "*.txt";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);

            // Begin watching the directory.
            watcher.EnableRaisingEvents = true;
        }

        static void OnChanged(object source, FileSystemEventArgs e)
        {
            watcher.EnableRaisingEvents = false;
            //Read the file that has been changed
            if (e.Name == "Cars.txt")
            {
                using (StreamReader sr = File.OpenText(e.FullPath))
                {
                    string input = null;
                    while ((input = sr.ReadLine()) != null)
                    {
                        string[] values = input.Split(';');
                       
                        double rentPrice = double.Parse(values[4]);
                        Cardealer.Instance.RegisterCar(values[0], values[1], values[2], double.Parse(values[3]), double.Parse(values[4]));
                    }
                }
            }
            else if (e.Name == "PrivateCustomers.txt")
            {
                using (StreamReader sr = File.OpenText(e.FullPath))
                {
                    string input = null;
                    while ((input = sr.ReadLine()) != null)
                    {
                        string[] values = input.Split(';');
                        Cardealer.Instance.RegisterPrivateCustomer(values[0], values[1], values[2], values[3], values[4]);
                    }
                }
            }
            else if (e.Name == "BusinessCustomers.txt")
            {
                using (StreamReader sr = File.OpenText(e.FullPath))
                {
                    string input = null;
                    while ((input = sr.ReadLine()) != null)
                    {
                        string[] values = input.Split(';');
                        Cardealer.Instance.RegisterBusinessCustomer(values[0], values[1], values[2], values[3], values[4]);
                    }
                }
            }
            watcher.EnableRaisingEvents = true;
        }
    }
}
