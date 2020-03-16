using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallHealth : MonoBehaviour {

    public GameObject fireWall;
    public int startingHealth = 1000;
    public int curHealth;

	// Use this for initialization
	void Start () {
		
	}
	
    void Awake()
    {
        curHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        curHealth = curHealth - amount;
    }

    void Death()
    {
        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
