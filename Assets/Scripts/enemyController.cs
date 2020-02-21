using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {
    public float moveSpeed = 50.0f;
    public GameObject fireWall;
    private Transform target;

    
    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("fireWall").transform;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x += moveSpeed * (target.position.x - pos.x) * Time.deltaTime;
        pos.y += moveSpeed * (target.position.y - pos.y) * Time.deltaTime;
        transform.position = pos;
    } 
}
