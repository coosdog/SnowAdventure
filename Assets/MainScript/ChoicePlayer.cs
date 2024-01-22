using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicePlayer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) && transform.position.z < 75)
        {
            transform.position += new Vector3(0, 0, 5);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.z >0)
        {
            transform.position += new Vector3(0, 0, -5);
        }
    }
}
