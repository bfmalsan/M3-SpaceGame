using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject playerObject;

    public void UpgradeHealth()
    {
        playerObject.GetComponent<Player>().IncreaseHealth(1);
        gameManager.StartRound();
    }

    public void UpgradeFireRate()
    {
        playerObject.GetComponent<PlayerShoot>().ShootFaster(0.1f);
        gameManager.StartRound();
    }

    public void UpgradeDamage()
    {
        playerObject.GetComponent<PlayerShoot>().IncreaseDamage(1);
        gameManager.StartRound();
    }
}
