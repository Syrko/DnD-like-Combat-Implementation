using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using Assets.Combat;
using System;

namespace Assets.Dataset
{
    /// <summary>
    /// Class containing the methods with all the calls to the sqlite database we use.
    /// Implemented as a singleton.
    /// </summary>
    class DatabaseHelper
    {
        private static string connection_string = "URI=file:" + Application.dataPath + "/Dataset/DnDEquipment.s3db";
        private static DatabaseHelper instance = null;

        private DatabaseHelper()
        {
            
        }
        
        /// <summary>
        /// Constructs or gets the already constructed DatabaseHelper
        /// </summary>
        /// <returns>DatabaseHelper objet</returns>
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


        /// <summary>
        /// Get the weapon from the database as a Weapon object
        /// </summary>
        /// <param name="weaponName">String with the weapon's name</param>
        /// <returns>Weapon object. Note: you can cast the Weapon into any of the children classes(e.g Dagger)</returns>
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

        /// <summary>
        /// Get the armor piece from the database as an Armor object
        /// </summary>
        /// <param name="armorName">String with the armor's name</param>
        /// <returns>Armor object. Note: you can cast the Armor into any of the children classes(e.g Breastplate)</returns>
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
