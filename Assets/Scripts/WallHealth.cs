using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHealth : MonoBehaviour {

    public GameObject fireWall;
    public Slider healthBar;
    public static int Health;
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
        Health = 500;
        UpdateHealth();
        GameOverObjects = GameObject.FindGameObjectsWithTag("GameOver");
        HideGameOver();
    }

    void Update()
    {
        healthBar.value = Health;
        if (Health <= 0)
        {
            Destroy(gameObject);
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                gManager.SaveScoreboard();
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
        healthBar.value = Health;
    }
}
