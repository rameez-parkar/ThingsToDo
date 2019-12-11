using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThingsToDo
{
    public class DatabaseHandler
    {
        MySqlConnection connection;
        MySqlCommand command;
        string serverName;
        string userId;
        string database;
        string password;

        public DatabaseHandler(string serverName, string userId, string database, string password)
        {
            this.serverName = serverName;
            this.userId = userId;
            this.database = database;
            this.password = password;
        }

        public void Connect()
        {
            string configuration = "server=" + this.serverName + ";user id=" + userId + ";database=" + this.database + ";password=" + this.password;
            connection = new MySqlConnection(configuration);
            connection.Open();
            Console.WriteLine("Connection with Database established!!");
        }

        public void Disconnect()
        {
            connection.Close();
            Console.WriteLine("Disconnected with Database...");
        }

        public void CreateTable(string tableName, string newTableInfo)
        {
            try
            {
                command = new MySqlCommand(newTableInfo, connection);
                int noOfRowsAffected = command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                DeleteTable(tableName);
                command = new MySqlCommand(newTableInfo, connection);
                int noOfRowsAffected = command.ExecuteNonQuery();
            }
            Console.WriteLine("Created Table "+tableName);
        }

        public void InsertData(string tableName, PointsOfInterest pointsOfInterest)
        {
            string insertCommand = "insert into "+tableName+" values ("+pointsOfInterest.regionId+",\""+pointsOfInterest.regionName+ "\",\"" + pointsOfInterest.regionNameLong+ "\",\"" + pointsOfInterest.latitude+ "\",\"" + pointsOfInterest.longitude+ "\",\"" + pointsOfInterest.subClassification+ "\")";
            command = new MySqlCommand(insertCommand, connection);
            int noOfRowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("Region ID : "+pointsOfInterest.regionId+" inserted!");
        }

        public void DeleteTable(string tableName)
        {
            command = new MySqlCommand("drop table " + tableName, connection);
            int noOfRowsAffected = command.ExecuteNonQuery();
        }
    }
}
