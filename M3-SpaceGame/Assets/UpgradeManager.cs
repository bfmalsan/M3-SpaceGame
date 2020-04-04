using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameManager gameManager;

    public void UpgradeHealth()
    {
        gameManager.StartRound();
    }

    public void UpgradeFireRate()
    {
        gameManager.StartRound();
    }

    public void UpgradeDamage()
    {
        gameManager.StartRound();
    }
}
