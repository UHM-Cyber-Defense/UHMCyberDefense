using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform launchPosition;
    public AudioClip blasterSound;
    public float timeBullet = 0.0f;
    public float timeRefire = 0.1f;
    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsInvoking("FireBullet"))
            {
                InvokeRepeating("FireBullet", timeBullet, timeRefire);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("FireBullet");
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = launchPosition.position;
        if (Time.timeScale != 0)
        {
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 6000);
        }
        audio.clip = blasterSound;
        audio.Play();
    }
}