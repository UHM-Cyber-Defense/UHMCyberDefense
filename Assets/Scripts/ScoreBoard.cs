using System.Collections;
using System.Collections.Generic;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
using System.Text.RegularExpressions;
>>>>>>> Stashed changes
=======
using System.Text.RegularExpressions;
>>>>>>> Stashed changes
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

//IN PROGRESS
//NOT IMPLEMENTED
public class ScoreBoard : MonoBehaviour {

<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public string userScore;
    int scoreVal;
    int tempVal;
	// Use this for initialization
	void Start () {
		
	}
=======
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
>>>>>>> Stashed changes
	
	// Update is called once per frame
	void Update () {
		
	}

<<<<<<< Updated upstream
    /*public void SaveScoreboard()
=======
    public void SaveScoreboard()
>>>>>>> Stashed changes
=======
	
    public void SaveScoreboard()
>>>>>>> Stashed changes
    {
        if (File.Exists(Application.persistentDataPath + "/Scoreboard.dat"))
        {
            string path = Application.persistentDataPath
                       + "/Scoreboard.dat";
            int i = 0;
            string tempScore;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
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
=======
=======
>>>>>>> Stashed changes
            //Read file into string array
            string[] lines = File.ReadAllLines(path);
            userScore = player1.score.ToString() + " " + LoginPlayer.savedUser ;
            //Debug.Log("userScore is: " + userScore);
            tempVal = player1.score;
<<<<<<< Updated upstream
=======
            //This foreach loops goes through and sorts our new
            //score into the scoreboard
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        }
        else
        {
            StreamWriter file = File.CreateText(Application.persistentDataPath + "/Scoreboard.dat");
            userScore = LoginPlayer.savedUser + " " + playerScore.score.ToString();
            file.WriteLine(userScore);
            file.Close();
        }
    }
<<<<<<< Updated upstream

    public void LoadScoreboard()
    {
        if (File.Exists(Application.persistentDataPath + "/Scoreboard.dat"))
        {
<<<<<<< Updated upstream
            string path = Application.persistentDataPath
                       + "/Scoreboard.dat";
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {

            }*/
=======
            string scoreBoard;
            string path = Application.persistentDataPath
                       + "/Scoreboard.dat";
            string[] lines = File.ReadAllLines(path);
            scoreBoard = lines [0].Replace("***", "\r\n");
            SBText.text = scoreBoard;
        }
    }
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
}
