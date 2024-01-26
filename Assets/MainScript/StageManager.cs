using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject[] CheckStageObj;
    int CheckNum = 0;
   /*
    private static bool[] isCheckStage = new bool[15];
    public static bool[] IsCheckStage
    {
        get { return isCheckStage; }
        set 
        {
            isCheckStage = value;
        }
    }
   */
    private void Start()
    {
        GameManager.instance.StageNum = 1;
        for(int i = 0; i < GameManager.instance.IsCheckStage.Length; i++)
        {
            if (GameManager.instance.IsCheckStage[i] == true)
            {
                CheckNum++;
                CheckStageObj[i].SetActive(true);
                GameManager.instance.StageNum++;
            }
        }
    }
}
