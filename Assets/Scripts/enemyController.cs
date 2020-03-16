using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject tank;
    public GameObject bulletPrefab;
    public Transform launchPosition;
    public int damageValue = 1;
    public float timeRefire = 5.0f;
    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("CanShoot", Random.Range(2.0f, 10.0f), timeRefire);
    }
	
    void Awake()
    {
        
    }

    void CanShoot()
    {
        Vector3 rayOrigin = launchPosition.position;
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, launchPosition.transform.forward, out hit, 250))
        {
            if (hit.collider.tag != "Enemy")
            {
                FireBullet();
            }
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = launchPosition.position;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 4000);
    }

    // Update is called once per frame
    void Update () {
        Vector3 pos = transform.position;
        pos.z -= 0.1f;
        transform.position = pos;
    }
}
