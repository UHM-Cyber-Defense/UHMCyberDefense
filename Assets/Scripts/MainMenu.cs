using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

    public Text playerText;

	// Use this for initialization
	void Start () {
        Cursor.visible = true;
        playerText.text = "Player: " + LoginPlayer.savedUser;
        //Debug.Log(LoginPlayer.savedUser);
    }
	
	// Update is called once per frame
	void Update () {
        Cursor.visible = true;
    }

    public void StartGame(string sceneName)
    {
        if (LoginPlayer.savedUser != null)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            //Debug.Log("Not Logged In");
            playerText.text = "Login to Play!";
        }
    }
}
