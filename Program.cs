using Microsoft.Win32;
using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        Console.Title = "ReviOSChecker";
        Console.ForegroundColor = ConsoleColor.White;

        string computerName = Environment.MachineName;
        bool revisionToolExists = Directory.Exists(Path.GetPathRoot(Environment.SystemDirectory) + "Program Files (x86)\\Revision Tool");
       
        RegistryKey systemSupportKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\OEMInformation");

        string manufacturer = (string)systemSupportKey.GetValue("Manufacturer");
        string model = (string)systemSupportKey.GetValue("Model");
        string supportAppUrl = (string)systemSupportKey.GetValue("SupportAppURL");
        string supportProvider = (string)systemSupportKey.GetValue("SupportProvider");
        string supportURL = (string)systemSupportKey.GetValue("SupportURL");

        if (computerName.ToLower().Trim().Contains("revision") ||
            manufacturer.ToLower().Trim().Contains("revision") ||
            model.ToLower().Trim().Contains("revios") ||
            supportAppUrl.ToLower().Trim().Contains("revision") ||
            supportProvider.ToLower().Trim().Contains("revision") ||
            supportURL.ToLower().Trim().Contains("revision") ||
            revisionToolExists)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("SUCCESS");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] This system is using ReviOS.");
        }
        else
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("FAILED");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] This system is NOT using ReviOS.");
        }

        Console.WriteLine("");

        if (computerName.ToLower().Trim().Contains("revision"))
        {
            Passed("Computer Name Check", computerName);
        }
        else
        {
            NotPassed("Computer Name Check", computerName);
        }

        if (manufacturer.ToLower().Trim().Contains("revision"))
        {
            Passed("Manufacturer Check", manufacturer);
        }
        else
        {
            NotPassed("Manufacturer Check", manufacturer);
        }

        if (model.ToLower().Trim().Contains("revios"))
        {
            Passed("Model Check", model);
        }
        else
        {
            NotPassed("Model Check", model);
        }

        if (supportAppUrl.ToLower().Trim().Contains("revision"))
        {
            Passed("Support App URL Check", supportAppUrl);
        }
        else
        {
            NotPassed("Support App URL Check", supportAppUrl);
        }

        if (supportProvider.ToLower().Trim().Contains("revision"))
        {
            Passed("Support Provider Check", supportProvider);
        }
        else
        {
            NotPassed("Support Provider Check", supportProvider);
        }

        if (supportURL.ToLower().Trim().Contains("revision"))
        {
            Passed("Support URL Check", supportURL);
        }
        else
        {
            NotPassed("Support URL Check", supportURL);
        }

        if (revisionToolExists)
        {
            Passed("Revision Tool Check", "'" + Path.GetPathRoot(Environment.SystemDirectory) + "Program Files (x86)\\Revision Tool' path exists.");
        }
        else
        {
            NotPassed("Revision Tool Check", "'" + Path.GetPathRoot(Environment.SystemDirectory) + "Program Files (x86)\\Revision Tool' path does NOT exists.");
        }

        Console.ReadLine();
    }

    public static void Passed(string type, string details)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("PASSED");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("] [");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(type);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("] " + details);
        Console.WriteLine();
    }

    public static void NotPassed(string type, string details)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("NOT PASSED");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("] [");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(type);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("] " + details);
        Console.WriteLine();
    }
}