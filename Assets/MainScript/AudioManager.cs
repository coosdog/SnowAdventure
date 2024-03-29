using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : Singleton<AudioManager>
{
    public GameObject audioComponentPrefab;
    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        base.Awake();
        Init();
    }
    void Init()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(audioComponentPrefab);
            temp.SetActive(false);
            pool.Enqueue(temp);
        }
    }
    
    public AudioComponent Pop()
    {
        pool.Peek().SetActive(true);
        return pool.Dequeue().GetComponent<AudioComponent>();
    }

    public void Play(AudioClip clip, Transform target)
    {
        if (pool.Count < 5)
        {
            Init();
        }
        AudioComponent temp = Pop();
        temp.transform.parent = target;
        temp.transform.position = target.transform.position; 
        temp.Play(clip);
    }

    public void RetrunPool(GameObject returnObj)
    {
        returnObj.SetActive(false);
        pool.Enqueue(returnObj);
    }
    public void ClearPool()
    {
        pool.Clear();
    }

}
