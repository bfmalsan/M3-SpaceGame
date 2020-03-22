using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject EnemyBulletGO;
    public GameObject spawnPoint;

    public float fireRate = 0.5F;

    private bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            StartCoroutine(shoot());
        }
    }

    public IEnumerator shoot()
    {
        GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);
        bullet.transform.position = spawnPoint.transform.position;
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
