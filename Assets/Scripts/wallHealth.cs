using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHealth : MonoBehaviour {

    public GameObject fireWall;
<<<<<<< Updated upstream
    public int Health;
    public Text healthText;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    GameObject[] GameOverObjects;
    // Use this for initialization
    void Start () {
=======
=======
>>>>>>> Stashed changes
=======
    public Slider healthBar;
    public static int Health;
>>>>>>> Stashed changes
    private ScoreBoard gManager;
    GameObject[] GameOverObjects;
    // Use this for initialization
    void Start () {
        GameObject gameManager = GameObject.FindWithTag("GameManager");
        if (gameManager != null)
        {
            gManager = gameManager.GetComponent<ScoreBoard>();
        }
        if (gManager == null)
        {
            Debug.Log("Cannot find 'ScoreBoard' script");
        }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        Health = 500;
        UpdateHealth();
        GameOverObjects = GameObject.FindGameObjectsWithTag("GameOver");
        HideGameOver();
    }

    void Update()
    {
<<<<<<< Updated upstream
=======
        healthBar.value = Health;
>>>>>>> Stashed changes
        if (Health <= 0)
        {
            Destroy(gameObject);
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
                gManager.SaveScoreboard();
>>>>>>> Stashed changes
=======
                gManager.SaveScoreboard();
>>>>>>> Stashed changes
=======
                gManager.SaveScoreboard();
>>>>>>> Stashed changes
                ShowGameOver();
            }
        }
    }

    public void ShowGameOver()
    {
        foreach (GameObject g in GameOverObjects)
        {
            g.SetActive(true);
        }
    }

    public void HideGameOver()
    {
        foreach (GameObject g in GameOverObjects)
        {
            g.SetActive(false);
        }
    }

    public void TakeDamage(int amount)
    {
        Health = Health - amount;
        UpdateHealth();
    }

    void UpdateHealth()
    {
<<<<<<< Updated upstream
        healthText.text = "Firewall: " + Health;
=======
        healthBar.value = Health;
>>>>>>> Stashed changes
    }
}
