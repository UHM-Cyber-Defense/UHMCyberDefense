using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject tank;
    public GameObject bulletPrefab;
    public Transform launchPosition;
    public AudioClip blasterSound;
    public AudioClip wallImpact;
    private int damageValue = 5;
    private WallHealth wHealth;
    AudioSource audio;
    // Use this for initialization
    void Start ()
    {
        audio = GetComponent<AudioSource>();
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
        audio.clip = blasterSound;
        audio.Play();
    }

    // Update is called once per frame
    void Update () {
        Vector3 pos = transform.position;
        pos.z -= 0.05f;
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
            audio.clip = wallImpact;
            audio.Play();
        }
    }
}
