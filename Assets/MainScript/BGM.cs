using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioClip bgm;
    void Start()
    {
        Debug.Log("��� ��");
        AudioManager.instance.Play(bgm, this.transform);
    }

}
