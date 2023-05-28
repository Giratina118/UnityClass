using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public float MoveSpeed = 1.0f;
    public int HP = 3;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            HP--;
        }
        
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void UpdateMove()
    {
        transform.Translate(-Time.deltaTime * MoveSpeed, 0.0f, 0.0f);
    }

    void Update()
    {
        UpdateMove();
    }
}
