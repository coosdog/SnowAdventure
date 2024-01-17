using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public CinemachineFreeLook cam;

    private void Start()
    {
        cam = GetComponent<CinemachineFreeLook>();
    }
    void Update()
    {
        //cam.m_YAxis.m_InputAxisValue = -Input.GetAxis("Mouse Y");
        cam.m_XAxis.m_InputAxisValue = -Input.GetAxis("Mouse X");
    }
}
