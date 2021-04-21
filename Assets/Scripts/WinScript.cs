using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{

    public GameObject winPanel;
    public GameObject inGameUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            winPanel.SetActive(true);
            inGameUI.SetActive(false);
        }
    }
}
