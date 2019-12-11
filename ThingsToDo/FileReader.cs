using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ThingsToDo
{
    public class FileReader
    {
        string path;
        PointsOfInterest pointsOfInterest;
        DatabaseHandler dbHandler;

        public FileReader(string path, DatabaseHandler dbHandler)
        {
            this.path = path;
            this.dbHandler = dbHandler;
        }

        public void ReadData()
        {
            using (StreamReader streamReader = File.OpenText(path))
            {
                string row = "";
                streamReader.ReadLine();
                while((row=streamReader.ReadLine()) != null)
                {
                    PointsOfInterest pointsOfInterest = DataParser(row);
                    dbHandler.InsertData("PointsOfInterest", pointsOfInterest);
                }
            }
        }

        public PointsOfInterest DataParser(string row)
        {
            string[] rowEntry = row.Split('|');
            pointsOfInterest = new PointsOfInterest();
            if(rowEntry[0].Contains(" "))
            {
                rowEntry[0] = rowEntry[0].Replace(" ", "");
            }
            pointsOfInterest.regionId = int.Parse(rowEntry[0]);
            pointsOfInterest.regionName = rowEntry[1];
            pointsOfInterest.regionNameLong = rowEntry[2];
            pointsOfInterest.latitude = rowEntry[3];
            pointsOfInterest.longitude = rowEntry[4];
            pointsOfInterest.subClassification = rowEntry[5];
            return pointsOfInterest;
        }
    }
}
