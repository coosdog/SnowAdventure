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
public class Player : MonoBehaviour, IHitable, IAttackable
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

    float jumpCool = 3;
    float jumpCoolMax = 3;


    public void InputSound(AudioClip clip)
    {
        //AM.mainaudio.clip = clip;
        //AM.mainaudio.Play();
    }

    void Start()
    {
        //transform.position = startPoint.transform.position;
        state = playerState.stay;
        pMove = GetComponent<PlayerActivite>();
        isPlay = true;
    }

    void Update()
    {

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

    IEnumerator JumpCool()
    {

        pMove.Jump();
        pMove.isJump = false;
        uiManager.cencleCool.gameObject.SetActive(true);

        while (jumpCool > 0f)
        {
            jumpCool -= 1 * Time.deltaTime;
            uiManager.cencleCool.fillAmount = (jumpCool / jumpCoolMax);
            yield return new WaitForFixedUpdate();
        }
        uiManager.cencleCool.gameObject.SetActive(false);

        jumpCool = jumpCoolMax;
        pMove.isJump = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), 0.6f);
    }

    public void Hit()
    {
        throw new System.NotImplementedException();
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
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
