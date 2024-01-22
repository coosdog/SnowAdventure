using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerActivite : MonoBehaviour
{
    Player player;
    Collider colldier;
    Animator animator;
    Rigidbody rb;
    public Camera cam;

    int Speed = 10;
    float jumpPower = 60;
    float maxRay = 1;

    float horizontal;
    float vertical;

    [SerializeField]
    bool isGround;
    public bool isJump = true;

    RaycastHit hit;
    Vector3 RayPosition;
    Vector3 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
        colldier = GetComponent<Collider>();
        animator = GetComponent<Animator>();
    }
    public void TriggerMove()
    {
        colldier.isTrigger = true;
    }
    public void Jump()
    {
        rb.velocity = Vector3.zero;
        animator.SetTrigger("Jump");
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
    private void FixedUpdate()
    {
        Debug.DrawRay(RayPosition, dir * maxRay, Color.yellow);

        if (horizontal != 0 || vertical != 0)
        {
            RayPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            
            animator.SetBool("IsRun", true);
            dir = cam.transform.localRotation* Vector3.forward * vertical 
                + cam.transform.localRotation*Vector3.right * horizontal;
            dir.y = 0;
            dir = dir.normalized;
            transform.rotation = Quaternion.LookRotation(dir*Speed);
            if (Physics.Raycast(RayPosition, dir * maxRay, out hit, maxRay)
                && hit.collider.gameObject.tag == "Ground")
            {
                    Debug.Log("µé¾î¿È");
                    return;
                
            }
            transform.Translate(dir * Time.deltaTime * Speed, Space.World);

        }
        else
        {
            animator.SetBool("IsRun", false);
        }

        

    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(Input.GetMouseButtonDown(0)) 
        {
            animator.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;
            Jump();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Ãæµ¹");
        if (collision.gameObject.tag == "Ground")
        {
            //rb.drag = 10;
            isGround = true;
            player.state = playerState.stay;
        }

    }

}
