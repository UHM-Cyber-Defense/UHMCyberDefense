using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class SBManager : MonoBehaviour {

    //Simple Script Driven Scoreboard making use of multiple text fields
    //for organization
    public Text SBNameText;
    public Text SBScoreText;
    // Use this for initialization
    void Start ()
    {
        if (File.Exists(Application.persistentDataPath + "/Scoreboard.dat"))
        {
            string scoreName = string.Empty;
            string scoreScore = string.Empty;
            int i = 0;
            //Read our Scoreboard
            string path = Application.persistentDataPath
                       + "/Scoreboard.dat";
            string[] lines = File.ReadAllLines(path);
            string[] lineParse;
            foreach (string line in lines)
            {
                if (i < 10)
                {
                    lineParse = line.Split(new char[] { ' ' });
                    //Debug to make sure we split this correctly
                    /*for (int j = 0; j < lineParse.Length; j++)
                    {
                        Debug.Log(i);
                        Debug.Log(j);
                        Debug.Log(lineParse[j]);
                    }*/
                    //Split into one string of scores and one string of names.
                    //Easy way to format print to textfield with going through hoops.
                    scoreScore += lineParse[0] + '\n';
                    scoreName += lineParse[1] + '\n';
                    i++;
                }
            }
            SBNameText.text = scoreName;
            SBScoreText.text = scoreScore;
        }
    }
}
