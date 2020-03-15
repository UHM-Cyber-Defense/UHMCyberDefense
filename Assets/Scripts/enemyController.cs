using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject tank;
    wallHealth wHealth;
    // Use this for initialization
    void Start () {
        
	}
	
    void Awake()
    {
        wHealth = GetComponent<wallHealth>();
    }

	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.z -= 0.1f;
        transform.position = pos;
    }
}
