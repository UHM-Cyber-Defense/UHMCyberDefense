using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

//IN PROGRESS
//NOT IMPLEMENTED
public class ScoreBoard : MonoBehaviour {

    public string userScore;
    int scoreVal;
    int tempVal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*public void SaveScoreboard()
    {
        if (File.Exists(Application.persistentDataPath + "/Scoreboard.dat"))
        {
            string path = Application.persistentDataPath
                       + "/Scoreboard.dat";
            int i = 0;
            string tempScore;
            string[] trimScore;
            //Read file into string array
            string[] lines = File.ReadAllLines(path);
            userScore = LoginPlayer.savedUser + " " + playerScore.score.ToString();
            tempVal = playerScore.score;
            foreach (string line in lines)
            {
                trimScore = line.Split(new char[] { ' ' });
                scoreVal = Convert.ToInt32(trimScore);
                if (tempVal > scoreVal)
                {
                    tempScore = line;
                    lines[i] = userScore;
                    userScore = tempScore;
                    tempVal = scoreVal;
                    i++;
                }
            }
            File.AppendAllText(path, "\n" + userScore);
        }
        else
        {
            StreamWriter file = File.CreateText(Application.persistentDataPath + "/Scoreboard.dat");
            userScore = LoginPlayer.savedUser + " " + playerScore.score.ToString();
            file.WriteLine(userScore);
            file.Close();
        }
    }

    public void LoadScoreboard()
    {
        if (File.Exists(Application.persistentDataPath + "/Scoreboard.dat"))
        {
            string path = Application.persistentDataPath
                       + "/Scoreboard.dat";
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {

            }*/
}
