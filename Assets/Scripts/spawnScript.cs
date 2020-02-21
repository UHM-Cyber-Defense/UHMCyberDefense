using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour {

    public GameObject enemyPrefab;
    public Transform spawnPosition;
    public int count = 0;
    bool wallExist = true;

    void spawnTank()
    {
        GameObject tank = Instantiate(enemyPrefab) as GameObject;
        tank.transform.position = spawnPosition.position;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (count < 1)
        {
            Invoke("spawnTank", 5.0f);
            count += 1;
        }
	}
}
