using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Bullet : MonoBehaviour
{
    public float MoveSpeed = 1.0f;


    void Start()
    {
        Destroy(gameObject, 10.0f);
    }

    protected void UpdaetMove()
    {
        transform.Translate(Time.deltaTime * MoveSpeed, 0.0f, 0.0f);
    }

    void Update()
    {
        UpdaetMove();

    }
}
