using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject PlayerBulletGO;
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

    public IEnumerator shoot() {
        GameObject bullet = (GameObject)Instantiate(PlayerBulletGO);
        bullet.transform.position = spawnPoint.transform.position;
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

}
