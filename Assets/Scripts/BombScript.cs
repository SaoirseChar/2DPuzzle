using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombScript : MonoBehaviour
{
    public int liveslost = 0;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D Collider)
    {
        liveslost = liveslost + 1;
        gameObject.SetActive(false);
    }

}