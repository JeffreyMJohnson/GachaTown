using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;


namespace Assets._scripts
{
    public static class Database
    {
        private static string CONNECTION_STRING = "URI=file:" + Application.dataPath + Constants.LOCAL_DATABASE_PATH;

        public static bool AddGacha(Gacha gacha)
        {
            IDbConnection dbConn = (IDbConnection)new SqliteConnection(CONNECTION_STRING);
            dbConn.Open();//open connection to database
            IDbCommand dbCmd = dbConn.CreateCommand();
            string query = string.Format("INSERT INTO Collection (Name, Prefab) VALUES ('{0}' ,'{1}' );", gacha.name, JsonUtility.ToJson(gacha));
            dbCmd.CommandText = query;
            int result = 0;
            try
            {
                result = dbCmd.ExecuteNonQuery();
            }
            catch (SqliteException e)
            {
                Debug.LogException(e);
            }
            finally
            {
                dbCmd.Dispose();
                dbCmd = null;
                dbConn.Close();
                dbConn = null;
            }
            return result == 1;

        }

        public static List<Gacha> GetGachas()
        {
            IDbConnection dbConn = (IDbConnection)new SqliteConnection(CONNECTION_STRING);
            dbConn.Open();//open connection to database
            IDbCommand dbCmd = dbConn.CreateCommand();

            string query = "SELECT Name FROM Collection";
            dbCmd.CommandText = query;
            IDataReader reader = dbCmd.ExecuteReader();
            if (reader.FieldCount == 0)
            {
                return null;
            }
            List<Gacha> result = new List<Gacha>();
            while (reader.Read())
            {
                Gacha gacha = new Gacha();
                gacha.name = reader.GetString(0);
                //gacha.prefab = JsonUtility.FromJson<GameObject>(reader.GetString(1));
                result.Add(gacha);
            }
            reader.Close();
            reader = null;
            dbCmd.Dispose();
            dbCmd = null;
            dbConn.Close();
            dbConn = null;
            return result;
        }
    }

    public class DatabaseInsertException : Exception
    {
        public DatabaseInsertException()
        {

        }
        public DatabaseInsertException(string message) : base(message)
        {

        }
        public DatabaseInsertException(string message, Exception inner) : base(message, inner)
        {

        }


    }


}
