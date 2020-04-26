using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

    public Text playerText;

	// Use this for initialization
	void Start () {
        playerText.text = "Player: " + LoginPlayer.savedUser;
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }
	
	// Update is called once per frame
	void Update () {
        //playerText.text = "Player: "+ LoginPlayer.savedUser;
	}

    public void StartGame(string sceneName)
    {
        if (LoginPlayer.savedUser != null)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Not Logged In");
            playerText.text = "Login to Play!";
        }
    }
}
