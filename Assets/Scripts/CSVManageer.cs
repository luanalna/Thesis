using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CSVManager : MonoBehaviour
{
    public TextAsset csvFile; // Reference to the CSV file
    public float CameraDir; // Public member for speed
    public float TargetDir; // Public member for direction
    public static int rowCount = 1; // Static counter to track the number of rows read

    private List<DataRow> dataRows = new List<DataRow>(); // List to hold data rows

    float max_roars = 4;

    public bool ReadCSV_row()
    {

        bool status_success = false;
        
        string[] data = csvFile.text.Split(new char[] { '\n' }); // reads the whole file

        if (rowCount <= max_roars){
        
            string[] row = data[rowCount].Split(new char[] { ',' });

            DataRow dataRow = new DataRow
            {
                Speed = float.Parse(row[0]),
                Direction = float.Parse(row[1]),
                //Angle = string.IsNullOrEmpty(row[2]) ? 0 : float.Parse(row[2])
            };

            dataRows.Add(dataRow);

            // Update public members with the new values
            CameraDir = dataRow.Speed;
            TargetDir = dataRow.Direction;

            // Update the static counter
            rowCount++;

            // Update the return
            status_success = true;

            Debug.Log("Current speed: " + CameraDir);
            Debug.Log("Current dir: " + TargetDir);
            Debug.Log("Current row: " + rowCount);
        }
        else {
            Debug.Log("END FILE");
        }
    return status_success;
    }
}

public class DataRow
{
    public float Speed { get; set; }
    public float Direction { get; set; }
    public float Angle { get; set; }
}
