using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTrigger : MonoBehaviour
{
    public int UniqueNum;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ChoicePlayer>() != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (UniqueNum <= GameManager.instance.StageNum)
                    SceneManager.LoadScene("Stage_"+UniqueNum);
                else
                    Debug.Log("아직 자격이 없습니다.");
            }
        }
    }



}
