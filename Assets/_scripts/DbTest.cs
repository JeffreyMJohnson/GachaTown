using UnityEngine;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;

using Assets._scripts;


public class DbTest : MonoBehaviour
{
    public GameObject myPrefab;

    // Use this for initialization
    void Start()
    {
        Gacha myGacha = new Gacha();
        myGacha.name = "FooBar";
        myGacha.prefab = myPrefab;

        string gachaString = JsonUtility.ToJson(myGacha);


        string conn = "URI=file:" + Application.dataPath + "/Database/TestDB1.db";//path to database
        IDbConnection dbConn = (IDbConnection)new SqliteConnection(conn);
        dbConn.Open();//open connection to database
        IDbCommand dbCmd = dbConn.CreateCommand();

        string query = string.Format("UPDATE User SET Gacha='{0}' WHERE Name='Foo'", gachaString);
        dbCmd.CommandText = query;
        dbCmd.ExecuteNonQuery();
        query = "SELECT ID, Name, Gacha FROM User WHERE Gacha NOT NULL";
        dbCmd.CommandText = query;
        IDataReader reader = dbCmd.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string gacha = "";
            gacha = reader.GetString(2);
            


            Debug.Log(string.Format("ID: {0}\nName: {1}\nGacha: {2}", id, name, gachaString));
        }
        reader.Close();
        reader = null;
        dbCmd.Dispose();
        dbCmd = null;
        dbConn.Close();
        dbConn = null;

        Gacha myNewGacha = JsonUtility.FromJson<Gacha>(gachaString);

        Instantiate<GameObject>(myNewGacha.prefab);
    }
}
