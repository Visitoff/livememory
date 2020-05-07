using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimatyTankFire : MonoBehaviour
{
    public bool a = true;
    public GameObject bulletPrefab;
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public float nextTimeToFire;

    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public float shotPower = 100f;
    public GameObject casingPrefab;
    public Transform casingExitLocation;
    AudioSource m_MyAudioSource;
        
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((a == true) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 10f / fireRate;
            Shoot();
            Bullet();

        }

    }
    public void Shoot()
    {
        // копирование патрона и задавание ему стартовой позиции
        GameObject tempFlash;
        tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
        Destroy(tempFlash, 0.5f); // на эффекте
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.Play();




    }
    public void Bullet()
    {
        GetComponent<AudioSource>().Play();
        GameObject bullet;
        bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower); // обратный эдд форсе
        Destroy(bullet, 0.7f); // только если не во что не попал
    }
}
