using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject pausePanel;
    public GameObject inGamePanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            inGamePanel.SetActive(false);
            pausePanel.SetActive(true);
        }
    }

    public void Play()
    {
        Time.timeScale = 1;
    }
}
