using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBManager : MonoBehaviour {

    private ScoreBoard scoreBManager;
	// Use this for initialization
	void Start () {
        GameObject sbManager = GameObject.FindWithTag("SBManager");
        if (sbManager != null)
        {
            scoreBManager = sbManager.GetComponent<ScoreBoard>();
        }
        if (scoreBManager == null)
        {
            Debug.Log("Cannot find 'ScoreBoard' script");
        }
        scoreBManager.LoadScoreboard();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
