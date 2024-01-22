using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("무기 작동");
        if(collision.gameObject.GetComponent<Monster>() != null)
        {
            Debug.Log("주금");
            collision.gameObject.GetComponent<Monster>().Hit();
        }
    }
}
