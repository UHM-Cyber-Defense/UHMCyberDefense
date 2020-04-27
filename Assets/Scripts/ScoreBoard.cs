using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

//IN PROGRESS
//NOT IMPLEMENTED
public class ScoreBoard : MonoBehaviour {

    private PlayerController player1;
    string userScore;
    string tempScore;
    static int scoreVal;
    static int tempVal;
    public Text SBText;
    // Use this for initialization
    void Start () {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player1 = playerObject.GetComponent<PlayerController>();
        }
        if (player1 == null)
        {
            Debug.Log("Cannot find 'PlayerController' script");
        }
    }
	
    public void SaveScoreboard()
    {
        if (File.Exists(Application.persistentDataPath + "/Scoreboard.dat"))
        {
            string path = Application.persistentDataPath
                       + "/Scoreboard.dat";
            int i = 0;
            string tempScore;
            //Read file into string array
            string[] lines = File.ReadAllLines(path);
            userScore = player1.score.ToString() + " " + LoginPlayer.savedUser ;
            //Debug.Log("userScore is: " + userScore);
            tempVal = player1.score;
            //This foreach loops goes through and sorts our new
            //score into the scoreboard
            foreach (string line in lines)
            {
                //trimScore = line.Split(new char[] { ' ' });
                tempScore = Regex.Match(line, "\\d+").Value;
                scoreVal = Int32.Parse(tempScore);
                //Debug.Log("scoreVal is: " + scoreVal);
                if (tempVal > scoreVal)
                {
                    i++;
                    tempScore = line;
                    lines[i] = userScore;
                    //Debug.Log("lines[" + i + "] is: " + lines[i]);
                    userScore = tempScore;
                    tempVal = scoreVal;
                }
            }
            StreamWriter file = new StreamWriter(path);
            foreach (string line in lines)
            {
                file.WriteLine(line);
            }
            file.Close();
            //Debug.Log("userScore is: " + userScore);
            File.AppendAllText(path, userScore);
        }
        else
        {
            StreamWriter file = File.CreateText(Application.persistentDataPath + "/Scoreboard.dat");
            userScore = LoginPlayer.savedUser + " " + playerScore.score.ToString();
            file.WriteLine(userScore);
            file.Close();
        }
    }
}
