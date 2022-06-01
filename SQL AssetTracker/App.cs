﻿using System.Data.SqlClient;
using System.Runtime.InteropServices;



namespace SQL_AssetTracker
{
    class App
    {
        // Setup Fullscreen.
        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        // SQL?
        

        static void Main(string[] args)
        {
            // Apply Fullscreen.
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight); // This line works ONLY for Windows OS.
            ShowWindow(ThisConsole, MAXIMIZE);
            Console.WriteLine("Wait for application to connect to SQL Server...");

            //Run AppLogic class and method here...
            AppLogic app = new AppLogic();
            

            string connectionString;
            SqlConnection cnn;

            connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=AssetTracker;Trusted_Connection=True;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("Connected to SQL Server.");
            Console.ResetColor();
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();


            app.Start();
        }
    }

    internal class DatabaseParam
    {
    }
}