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
          GameManager.instance.StageNum = GameManager.instance.IsCheckStage.Length; // Ʈ���� ��鸸 ��ƾ���.
        Debug.Log("������ �ѱ�");
        AudioManager.instance.ClearPool();
        SceneManager.LoadScene("ChoiceScene");
    }
}
