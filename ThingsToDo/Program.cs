using System;
using MySql.Data.MySqlClient;

namespace ThingsToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Provide the path of the file to be read : ");
            string path = Console.ReadLine();

            Console.WriteLine("Enter the name of the table to be created in database : ");
            string tableName = Console.ReadLine();

            DatabaseHandler dbHandler = new DatabaseHandler("localhost", "root", "mydb", "root");
            dbHandler.Connect();

            dbHandler.CreateTable(tableName, "create table "+tableName+"(RegionID bigint, RegionName varchar(300), RegionNameLong varchar(500), Latitude decimal(10,6), Longitude decimal(10,6), SubClassification varchar(200))");
            FileReader fileReader = new FileReader(path, dbHandler);
            fileReader.ReadDataFromFile(tableName);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            dbHandler.Disconnect();
        }
    }
}
