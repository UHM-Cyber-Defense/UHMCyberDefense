using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class playerScore : MonoBehaviour {

    public int score = 0;
    public Text scoreText;
	// Use this for initialization
	void Awake () {
        scoreText = GetComponent<Text>();
	}
	
    void SetScore ()
    {
        scoreText.text = "Score: " + score;
    }
	// Update is called once per frame
	void Update () {
        
	}
}
