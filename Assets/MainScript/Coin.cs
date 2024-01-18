using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    int coinLimit = 3;
    Vector3 dir = Vector3.zero;
    Collider[] cols = null;
    //public GameManager gameManager;
    public AudioClip coinGet;

    void Update()
    {
        transform.Rotate(Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            other.GetComponent<Player>().InputSound(coinGet);
            //gameManager.CoinNum++;
            Destroy(gameObject);
        }
    }
}
