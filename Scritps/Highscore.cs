using Mono.Data.Sqlite; //Datenbank nutzen
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Highscore : MonoBehaviour
{
    public int level;
    public static int lastLevel;
    public TMP_Text maxScore;
    public static int highscore1 = 0;
    public static int highscore2 = 0;
    public static int highscore3 = 0;
    public static int highscore4 = 0;
    public static int highscore5 = 0;
    public static int highscore6 = 0;
    // Start is called before the first frame update
    void Start()
    {
        // setzt immer das letze level, um zu wissen welchen score und highscore man verwendet
        lastLevel = level;
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandReadValues = dbConnection.CreateCommand();
        dbCommandReadValues.CommandText = "SELECT * FROM Higscorestable";
        IDataReader dataReader = dbCommandReadValues.ExecuteReader();
        while (dataReader.Read()) 
        {
            var id = dataReader.GetInt32(0);  // id wird geladen
            var score = dataReader.GetInt32(1); // score wird gelesen
            switch (id) // 8
            {
                case 1:
                    highscore1 = score; 
                    break;
                case 2:
                    highscore2 = score; 
                    break;
                case 3:
                    highscore3 = score; 
                    break;
                case 4:
                    highscore4 = score;
                    break;
                case 5:
                    highscore5 = score;
                    break;
                case 6:
                    highscore6 = score;
                    break;
            }     
        }
        //always close the connection at the end.
        dbConnection.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isDead == true)
        {
            IsHighscore();
            

        }
        HighscoreText();
    }
    public void IsHighscore()
    {
        //Setzt den neuen highscore, wenn er höher als der alte ist
        if (lastLevel == 1)
        {
            if(ZombieMovement.score > highscore1)
            {
                highscore1 = ZombieMovement.score;
                HighscoreDB();
            }
        }
        if (lastLevel == 2)
        {
            if (ZombieMovement.score > highscore2)
            {
                highscore2 = ZombieMovement.score;
                HighscoreDB();
            }
        }
        if (lastLevel == 3)
        {
            if (ZombieMovement.score > highscore3)
            {
                highscore3 = ZombieMovement.score;
                HighscoreDB();
            }
        }
        if (lastLevel == 4)
        {
            if (ZombieMovement.score > highscore4)
            {
                highscore4 = ZombieMovement.score;
                HighscoreDB();
            }
        }
        if (lastLevel == 5)
        {
            if (ZombieMovement.score > highscore5)
            {
                highscore5 = ZombieMovement.score;
                HighscoreDB();
            }
        }
        if (lastLevel == 6)
        {
            if (ZombieMovement.score > highscore6)
            {
                highscore6 = ZombieMovement.score;
                HighscoreDB();
            }
        }
    }
    void HighscoreDB()
    {
        // Score speichern
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandInsertValue = dbConnection.CreateCommand();
        dbCommandInsertValue.CommandText = "INSERT OR REPLACE INTO Higscorestable (id, score) VALUES ("+lastLevel+","+ZombieMovement.score+")";
        dbCommandInsertValue.ExecuteNonQuery();
        dbConnection.Close();
    }
    private void HighscoreText()
    {
        //gibt highscore aus
        if (level == 1)
        {
            maxScore.text = "Highscore: " + highscore1;
        }
        if (level == 2)
        {
            maxScore.text = "Highscore: " + highscore2;
        }
        if (level == 3)
        {
            maxScore.text = "Highscore: " + highscore3;
        }
        if (level == 4)
        {
            maxScore.text = "Highscore: " + highscore4;
        }
        if (level == 5)
        {
            maxScore.text = "Highscore: " + highscore5;
        }
        if (level == 6)
        {
            maxScore.text = "Highscore: " + highscore6;
        }
    }
    private IDbConnection CreateAndOpenDatabase()
    {
        // Open a connection to the database.
        string dbUri = "URI=file:ZombieshooterDB.sqlite";
        IDbConnection dbConnection = new SqliteConnection(dbUri);
        dbConnection.Open();

        //Tabelle erstellen
        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand();
        dbCommandCreateTable.CommandText = "CREATE TABLE IF NOT EXISTS Higscorestable (id INTEGER PRIMARY KEY, score INTEGER )";//id ist das Level
        dbCommandCreateTable.ExecuteReader();

        return dbConnection;
    }
}
