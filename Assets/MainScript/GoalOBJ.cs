using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalOBJ : MonoBehaviour
{
    public int GoalNum;
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.IsCheckStage[GoalNum] = true;
          GameManager.instance.StageNum = GameManager.instance.IsCheckStage.Length; // 트루인 놈들만 잡아야함.
        Debug.Log("데이터 넘김");
        AudioManager.instance.ClearPool();
        SceneManager.LoadScene("ChoiceScene");
    }
}
