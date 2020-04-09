using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject tank;
    public GameObject bulletPrefab;
    public Transform launchPosition;
    private int damageValue = 10;
    private WallHealth wHealth;
    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("CanShoot", Random.Range(4.0f, 10.0f), Random.Range(5.0f, 10.0f));
        GameObject wallObject = GameObject.FindWithTag("Firewall");
        if (wallObject != null)
        {
            wHealth = wallObject.GetComponent<WallHealth>();
        }
        if (wHealth == null)
        {
            Debug.Log("Cannot find 'WallHealth' script");
        }
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
        if (Time.timeScale != 0)
        {
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 4000);
        }
    }

    // Update is called once per frame
    void Update () {
        Vector3 pos = transform.position;
        pos.z -= 0.1f;
        if (Time.timeScale != 0)
        {
            transform.position = pos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Firewall")
        {
            if (wHealth != null)
            {
                wHealth.TakeDamage(damageValue);
            }
            Destroy(gameObject);
        }
    }
}
