using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public int gunDamage = 1;
    // Use this for initialization
    void Start()
    {
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
            wallHealth health = GetComponent<wallHealth>();
            if (health != null)
            {
                health.TakeDamage(gunDamage);
            }
            Destroy(gameObject);
        }
    }
}
