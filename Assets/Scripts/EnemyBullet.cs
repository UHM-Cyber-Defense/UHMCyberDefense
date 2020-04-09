using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    private WallHealth wHealth;
    int gunDamage = 1;
    // Use this for initialization
    void Start()
    {
        GameObject wallObject = GameObject.FindWithTag("Firewall");
        if (wallObject != null)
        {
            wHealth = wallObject.GetComponent<WallHealth>();
        }
        if (wHealth == null)
        {
            Debug.Log("Cannot find 'WallHealth' script");
        }
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Firewall")
        {
            if (wHealth != null)
            {
                wHealth.TakeDamage(gunDamage);
            }
            Destroy(gameObject);
        }
    }
}
