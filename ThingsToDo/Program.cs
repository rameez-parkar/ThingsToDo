using System;
using MySql.Data.MySqlClient;

namespace ThingsToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseHandler dbHandler = new DatabaseHandler("localhost", "root", "mydb", "root");
            dbHandler.Connect();
            dbHandler.CreateTable("create table PointsOfInterest(RegionID int, RegionName varchar(300), RegionNameLong varchar(500), Latitude varchar(100), Longitude varchar(100), SubClassification varchar(200))");
            FileReader fileReader = new FileReader(@"C:\Users\rparkar\Desktop\ORXe\Training\ThingsToDo\sample.txt", dbHandler);
            fileReader.ReadData();
            //MySqlCommand command = new MySqlCommand("create table PointsOfInterest(RegionID int, RegionName varchar(300), RegionNameLong varchar(500), Latitude varchar(100), Longitude varchar(100), SubClassification varchar(200))", connection);
            //int count = command.ExecuteNonQuery();

        }
    }
}
