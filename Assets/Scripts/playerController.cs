using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    float speed = 100;

    // Use this for initialization
    void Start()
     {

     }

    private void FixedUpdate()
    {
        Vector3 dirVector = new Vector3(Input.GetAxis("Horizontal"), 0/*, Input.GetAxis("Vertical")*/).normalized;
        GetComponent<Rigidbody>().MovePosition(transform.position + dirVector * Time.deltaTime * speed);
    }
    void Update()
    {
    }
}

