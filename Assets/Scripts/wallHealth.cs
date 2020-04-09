using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHealth : MonoBehaviour {

    public GameObject fireWall;
    public int Health;
    public Text healthText;
    GameObject[] GameOverObjects;
    // Use this for initialization
    void Start () {
        Health = 500;
        UpdateHealth();
        GameOverObjects = GameObject.FindGameObjectsWithTag("GameOver");
        HideGameOver();
    }

    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
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
        healthText.text = "Firewall: " + Health;
    }
}
