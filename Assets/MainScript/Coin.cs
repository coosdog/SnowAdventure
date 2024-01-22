using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinGet;

    void Update()
    {
        transform.Rotate(Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            AudioManager.instance.Play(coinGet, this.transform);
            GameManager.instance.CoinNum++;
            Destroy(gameObject);
        }
    }
}
