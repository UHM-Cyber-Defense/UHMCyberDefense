using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class playerScore : MonoBehaviour {

    public static int score;
    public Text scoreText;
    // Use this for initialization

    private void Start()
    {
        score = 0;
    }
	
    public void SetScore (int scoreValue)
    {
        score += scoreValue;
        UpdateScore();
    }

    void UpdateScore ()
    {
        scoreText.text = "Score: " + score;
    }
	// Update is called once per frame
	void Update () {
        
	}
}
