using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    float speed = 100;
    public int score;
    public Text scoreText;

    // Use this for initialization
    void Start()
     {
        score = 0;
        UpdateScore();
     }

    private void FixedUpdate()
    {
        Vector3 dirVector = new Vector3(Input.GetAxis("Horizontal"), 0/*, Input.GetAxis("Vertical")*/).normalized;
        GetComponent<Rigidbody>().MovePosition(transform.position + dirVector * Time.deltaTime * speed);
    }

    public void SetScore(int scoreValue)
    {
        score += scoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}

