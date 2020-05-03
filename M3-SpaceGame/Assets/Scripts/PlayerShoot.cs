using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject PlayerBulletGO;
    public GameObject spawnPoint;

    public float fireRate = 0.5F;
    public int damage = 1;

    public void Shoot() {

        GameObject bullet = (GameObject)Instantiate(PlayerBulletGO);

        bullet.transform.position = spawnPoint.transform.position;
        bullet.GetComponent<PlayerBullet>().SetDamage(damage);
       
    }

    public void StartShooting()
    {
        InvokeRepeating("Shoot", 0f, fireRate);
    }

    public void StopShooting()
    {
        CancelInvoke("Shoot");
    }

    public void IncreaseDamage(int value)
    {
        damage += value;
    }

    public void DecreaseDamage(int value)
    {
        damage -= value;
    }

    public void ShootFaster(float value)
    {
        if(fireRate - value <= 0.1f) {
            fireRate = 0.1f;
        }
        else
        {
            fireRate -= value;
        }

    }

    public void ShootSlower(float value)
    {
        fireRate += value;
    }

    public void ResetValues()
    {
        fireRate = 1f;
        damage = 1;
    }

}
