using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using Assets.Combat;
using System;

namespace Assets.Dataset
{
    class DatabaseHelper
    {
        private static string connection_string = "URI=file:" + Application.dataPath + "/Dataset/DnDEquipment.s3db";
        private static DatabaseHelper instance = null;

        private DatabaseHelper()
        {
            
        }
        
        public static DatabaseHelper GetInstance()
        {
            if (instance != null)
                return instance;
            else
            {
                instance = new DatabaseHelper();
                return instance;
            }
        }

        public Weapon GetWeapon(string weaponName)
        {
            using(SqliteConnection dbConnection = new SqliteConnection(connection_string))
            {
                string sqlQuery = "SELECT * FROM Weapons WHERE name = @name";
                SqliteCommand command = new SqliteCommand(sqlQuery, dbConnection);

                command.Parameters.Add("@name", DbType.String);
                command.Parameters["@name"].Value = weaponName;

                try
                {
                    dbConnection.Open();
                    SqliteDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Die dieDamage = new Die(reader.GetString(reader.GetOrdinal("dieDamage")));
                        int numberOfDice = reader.GetInt32(reader.GetOrdinal("numberOfDice"));
                        string name = reader.GetString(reader.GetOrdinal("name"));
                        int range = reader.GetInt32(reader.GetOrdinal("range"));
                        bool isMartial = reader.GetBoolean(reader.GetOrdinal("isMartial"));
                        bool isFinesse = reader.GetBoolean(reader.GetOrdinal("isFinesse"));

                        return new Weapon(dieDamage, numberOfDice, name, range, isMartial, isFinesse);
                    }
                    else
                    {
                        throw new Exception("No weapon with such name found!");
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e.Message);
                    return null;
                }
            } 
        }

        public Armor GetArmor(string armorName)
        {
            using (SqliteConnection dbConnection = new SqliteConnection(connection_string))
            {
                string sqlQuery = "SELECT * FROM Armors WHERE name = @name";
                SqliteCommand command = new SqliteCommand(sqlQuery, dbConnection);

                command.Parameters.Add("@name", DbType.String);
                command.Parameters["@name"].Value = armorName;

                try
                {
                    dbConnection.Open();
                    SqliteDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string name = reader.GetString(reader.GetOrdinal("name"));
                        int ac = reader.GetInt32(reader.GetOrdinal("ac"));
                        bool stealthDisadvantage = reader.GetBoolean(reader.GetOrdinal("stealthDisadvantage"));
                        string type = reader.GetString(reader.GetOrdinal("type"));
                        int strengthRequirement = reader.GetInt32(reader.GetOrdinal("strengthRequirement"));
                        int maxDexterity = reader.GetInt32(reader.GetOrdinal("maxDexterity"));

                        return new Armor(ac, name, stealthDisadvantage, type, strengthRequirement, maxDexterity);
                    }
                    else
                    {
                        throw new Exception("No armor with such name found!");
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e.Message);
                    return null;
                }
            }
        }
    }
}
