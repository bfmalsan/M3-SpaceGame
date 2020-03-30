using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject PlayerBulletGO;
    public GameObject spawnPoint;

    public float fireRate = 0.5F;

    public void Shoot() {

        GameObject bullet = (GameObject)Instantiate(PlayerBulletGO);

        bullet.transform.position = spawnPoint.transform.position;
       
    }

    public void StartShooting()
    {
        InvokeRepeating("Shoot", 0f, fireRate);
    }

    public void StopShooting()
    {
        CancelInvoke("Shoot");
    }
}
