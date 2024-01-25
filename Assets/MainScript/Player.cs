using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static Interface;

public enum playerState
{
    stay,
    move,
    trap
}
public class Player : MonoBehaviour, IHitable
{
    public bool isPlay;
    [Header("Manager")]
    public GameManager gameManager;
    public UIManager uiManager;
    public AudioManager AM;

    [Header("Audio")]
    public AudioClip jumpAudio;
    public AudioClip moveAudio;
    public AudioClip attackAudio;

    [Header("Player")]
    public playerState state;
    public PlayerActivite pMove;

    [Header("others")]
    public GameObject attackRange;
    //public Satan satan;

    void Start()
    {
        //transform.position = startPoint.transform.position;
        state = playerState.stay;
        pMove = GetComponent<PlayerActivite>();
        isPlay = true;
    }


    void StepSound()
    {
        AudioManager.instance.Play(moveAudio, this.transform);
    }
    void jumpSound()
    {
        AudioManager.instance.Play(jumpAudio, this.transform);
    }
    void attackSound()
    {
        AudioManager.instance.Play(attackAudio, this.transform);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), 0.6f);
    }

    public void Hit()
    {
        this.gameObject.SetActive(false);
    }
    public void HitOn()
    {
        attackRange.SetActive(true);
    }
    public void HitOff()
    {
        attackRange.SetActive(false);
    }
}
