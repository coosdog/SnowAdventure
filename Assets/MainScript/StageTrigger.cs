using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTrigger : MonoBehaviour
{
    public int UniqueNum;
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("����");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("PublicStageStation");
        }
    }
    
        
    
}
