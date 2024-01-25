using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    public Shoot shoot;
    int moveSpeed = 5;
    private void Start()
    {
        shoot = GetComponentInParent<Shoot>();
        StartCoroutine(CollTime(5f));
    }
    void Update()
    {
        transform.position += this.transform.forward * Time.deltaTime *moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
            other.gameObject.GetComponent<Player>().Hit();
    }
    IEnumerator CollTime(float sec)
    {
        yield return new WaitForSecondsRealtime(sec);
        shoot.ReturnBullet(this.gameObject);
    }
}
