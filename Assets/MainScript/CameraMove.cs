using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    int maxDistance = 10;
    int moveSpeed = 10;

    public Player player;
    float absV;

    private void Start()
    {
    }
    void Update()
    {
        absV = Mathf.Abs(transform.position.z - player.transform.position.z);
        //cam.m_YAxis.m_InputAxisValue
        transform.position 
            = new Vector3(player.transform.position.x,player.transform.position.y+maxDistance,transform.position.z);
        if (absV < 10)
            transform.position -= Vector3.forward *Time.deltaTime * moveSpeed;
        if (absV > 15)
            transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }
}
