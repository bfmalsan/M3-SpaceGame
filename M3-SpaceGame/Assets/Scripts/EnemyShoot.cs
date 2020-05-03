using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject EnemyBulletGO;
    public GameObject spawnPoint;

    public float minFireRate = 1F;
    public float maxFireRate = 1.5f;

    private bool canShoot = true;

    // Update is called once per frame
    void Update()
    {   
        //Should not be allowed to shoot if the player is dead.
        if(GameObject.FindGameObjectWithTag("Player") == null){
            canShoot = false;
        }

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
        yield return new WaitForSeconds(Random.Range(minFireRate,maxFireRate));
        canShoot = true;
    }
}
