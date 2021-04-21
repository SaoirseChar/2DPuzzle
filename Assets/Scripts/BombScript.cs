using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombScript : MonoBehaviour
{
    public int livesLost = 0;
    public Text livesLostText;
    public GameObject deathPanel;
    public GameObject inGameUI;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Player"))
        {
            //livesLost = livesLost + 1;
            //livesLostText.text = "Lives Lost: " + livesLost;
            //gameObject.SetActive(false);

            Time.timeScale = 0;
            deathPanel.SetActive(true);
            inGameUI.SetActive(false);
        }
        
    }

}