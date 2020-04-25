using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour {

    public GameObject enemyPrefab;
    public Transform spawnPosition;
    int enemyCount = 0;
    int enemyTotal = 10;
    float spawnDelay = 200.0f;
    float timer = 0;
	
	// Update is called once per frame
	void Update () {
        if (enemyCount >= enemyTotal)
        {
            enemyCount = 0;
        }
        if(timer == spawnDelay){
            Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
            enemyCount++;
            timer = 0;
        }
        else
        {
            timer++;
        }
        
    }
}
