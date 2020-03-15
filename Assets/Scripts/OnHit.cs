using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnHit : MonoBehaviour {

    public int score = 0;
    public Text scoreText;
    // Use this for initialization
    void Start () {
        Destroy(gameObject, 3.0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    void SetScore()
    {
        scoreText.text = "Score: " + score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            //Debug.Log("HIT!");
            Destroy(other.gameObject);
            score++;
            SetScore();
            Destroy(gameObject);
        }
    }
}
