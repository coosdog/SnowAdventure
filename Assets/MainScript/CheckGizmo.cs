using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,3); // trap���� ���� exittrap�� limit
    }
}
