using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("���� �۵�");
        if(collision.gameObject.GetComponent<Monster>() != null)
        {
            Debug.Log("�ֱ�");
            collision.gameObject.GetComponent<Monster>().Hit();
        }
    }
}
