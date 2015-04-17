using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Domain.Filesystem
{
    class DirectoryWatcher
    {
        public DirectoryWatcher()
        {
            // Establish the path to the directory to watch.
            FileSystemWatcher watcher = new FileSystemWatcher();
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
              | NotifyFilters.DirectoryName;

            // Only watch text files.
            watcher.Filter = "*.txt";

            // Add event handlers.
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
        }

        static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: {a} {1}!", e.FullPath, e.ChangeType);
        }

        static void OnDeleted(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine("File: {a} renamed to {1}", e.FullPath, e.ChangeType);
        }
    }
}
