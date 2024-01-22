using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceCameraMove : MonoBehaviour
{

    public ChoicePlayer player;

    void Update()
    {
        if (player.transform.position.z > 70)
            return;
        else
            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
    }
}
