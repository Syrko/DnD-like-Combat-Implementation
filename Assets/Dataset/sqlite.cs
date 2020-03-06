using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class sqlite : MonoBehaviour
{
    string conn;
    // Start is called before the first frame update
    void Start()
    {
        conn = "URI=file:" + Application.dataPath + "/Dataset/DnDEquipment.s3db";

        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT name " + "FROM Armor";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            string name = reader.GetString(0);
            Debug.Log("name =" + name);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
