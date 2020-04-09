using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

    GameObject[] PauseObjects;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        PauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        HidePaused();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P))
        {
            Debug.Log("PAUSED");
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                ShowPaused();
            } else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                HidePaused();
            }
        }
	}

    public void UnPauseButton()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            HidePaused();
        }
    }

    public void ShowPaused()
    {
        foreach (GameObject g in PauseObjects)
        {
            g.SetActive(true);
        }
    }
    public void HidePaused()
    {
        foreach (GameObject g in PauseObjects)
        {
            g.SetActive(false);
        }
    }
}
