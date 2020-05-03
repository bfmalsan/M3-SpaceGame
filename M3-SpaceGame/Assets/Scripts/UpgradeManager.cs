using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject playerObject;

    public TextMeshProUGUI pointsUIText;

    public void UpgradeHealth()
    {
        playerObject.GetComponent<Player>().IncreaseHealth(1);

        playerObject.GetComponent<Player>().DecreaseUpgradePoints();
        
        if(playerObject.GetComponent<Player>().GetUpgradePoints() == 0){
            gameManager.StartRound();
        }
       
    }

    public void UpgradeFireRate()
    {
        playerObject.GetComponent<PlayerShoot>().ShootFaster(0.1f);

        playerObject.GetComponent<Player>().DecreaseUpgradePoints();
        

        if(playerObject.GetComponent<Player>().GetUpgradePoints() == 0){
            gameManager.StartRound();
        }
    }

    public void UpgradeDamage()
    {
        playerObject.GetComponent<PlayerShoot>().IncreaseDamage(1);

        playerObject.GetComponent<Player>().DecreaseUpgradePoints();
        

        if(playerObject.GetComponent<Player>().GetUpgradePoints() == 0){
            gameManager.StartRound();
        }
    }

    public void UpdatePointsText(){
        pointsUIText.text = playerObject.GetComponent<Player>().GetUpgradePoints().ToString();
    }

}
