﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour {

    private PlayerController player1;
<<<<<<< Updated upstream
    int scoreValue = 1;
    // Use this for initialization
    void Start ()
    {
=======
    public AudioClip enemyImpact;
    int scoreValue = 1;
    AudioSource audio;
    // Use this for initialization
    void Start ()
    {
        audio = GetComponent<AudioSource>();
>>>>>>> Stashed changes
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player1 = playerObject.GetComponent<PlayerController>();
        }
        if (player1 == null)
        {
            Debug.Log("Cannot find 'PlayerController' script");
        }
        Destroy(gameObject, 3.0f);
    }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
	
	// Update is called once per frame
	void Update ()
    {
		
	}
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            //Debug.Log("HIT!");
            Destroy(other.gameObject);
            Destroy(gameObject);
            player1.SetScore(scoreValue);
        }
        audio.clip = enemyImpact;
        audio.Play();
    }
}
