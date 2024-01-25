using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject ShootTransform;
    public Queue<GameObject> pool = new Queue<GameObject>();

    float makingTime = 2.5f;
    float limitTime = 1f;

    private void Awake()
    {
        Init();
    }
    void Start()
    {
        InvokeRepeating("MakeBullet", 1f, MakingTime);
    }

    void Init()
    {
        for (int i = 0; i < 10; i++) 
        {
            GameObject temp = Instantiate(Prefab);
            temp.transform.parent = transform;
            temp.transform.position = this.transform.position;
            temp.transform.rotation = this.transform.rotation;
            temp.SetActive(false);
            pool.Enqueue(temp);
        }
    }
    
    public float MakingTime
    {
        get { return makingTime; }
        set
        {
            makingTime = value;
            if (makingTime <= limitTime)
                makingTime = limitTime;
        }
    }
    void MakeBullet()
    {
        pool.Peek().SetActive(true);
        pool.Dequeue();
    }
    public void ReturnBullet(GameObject returnObj)
    {
        returnObj.transform.position = this.transform.position;
        returnObj.SetActive(false);
        pool.Enqueue(returnObj);
    }
    public void ShootBluuet()
    {
        CancelInvoke("MakeBullet");
        InvokeRepeating("MakeBullet", 1f, MakingTime);
    }
    

}
