using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject[] CheckStageObj;
    private static bool[] isCheckStage = new bool[15];
    public static bool[] IsCheckStage
    {
        get { return isCheckStage; }
        set 
        {
            isCheckStage = value;
        }
    }
    private void Start()
    {
        /*
        for (int i = 0; i < isCheckStage.Length; i++)
        {
            isCheckStage[i] = false;
        }
        */
        //IsCheckStage[0] = true;
    }
    private void Update()
    {
        if (isCheckStage[0]) 
        {
            CheckStageObj[0].SetActive(true);
        }
    }
}
