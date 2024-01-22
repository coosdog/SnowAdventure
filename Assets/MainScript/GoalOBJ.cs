using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalOBJ : MonoBehaviour
{
    public int GoalNum;
    private void OnTriggerEnter(Collider other)
    {
          GameManager.instance.StageNum++;
        StageManager.IsCheckStage[GoalNum] = true;
        Debug.Log("µ•¿Ã≈Õ ≥—±Ë");
        SceneManager.LoadScene("ChoiceScene");
    }
}
