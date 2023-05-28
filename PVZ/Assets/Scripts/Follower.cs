using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    //해바라기
    public float EventDelaySec = 1.0f;
    protected float m_NextSec = 0.0f;


    protected void UpdateEvent()
    {
        if (Time.time > m_NextSec)
        {
            m_NextSec = EventDelaySec + Time.time;
            CreateCoin();
        }
    }

    protected void CreateCoin()
    {
        GameObject obj = Resources.Load("Solar") as GameObject;
        GameObject cloneobj = GameObject.Instantiate(obj);

        Vector3 pos = this.transform.position;
        float range = 1.5f;

        Vector3 rand = Random.insideUnitCircle * range;
        pos = pos + rand;


        cloneobj.transform.position = pos;


    }


    void Start()
    {
        m_NextSec = EventDelaySec + Time.time;
    }


    void Update()
    {
        UpdateEvent();
    }
}
